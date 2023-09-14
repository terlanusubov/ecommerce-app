using EcommerceApp.MVC.Core;
using EcommerceApp.MVC.Core.Requests;
using EcommerceApp.MVC.Core.Responses;
using EcommerceApp.MVC.DTOs.Carts;
using EcommerceApp.MVC.Enums;
using EcommerceApp.MVC.Models;
using Microsoft.EntityFrameworkCore;
using static System.Net.Mime.MediaTypeNames;

namespace EcommerceApp.MVC.Interfaces
{
    public class CartService : ICartService
    {
        private readonly ApplicationDbContext _context;
        private readonly HttpContext _httpContext;
        private readonly IConfiguration _configuration;
        public CartService(ApplicationDbContext context,
            IHttpContextAccessor httpContextAccessor,
             IConfiguration configuration)
        {
            _context = context;
            _httpContext = httpContextAccessor.HttpContext;
            _configuration = configuration;
        }

        public async Task<ServiceResult<CartAddItemResponse>> AddItem(CartAddItemRequest request)
        {
            var userId = _httpContext.User.Claims.Where(c => c.Type == "Id").FirstOrDefault().Value;

            var cart = await _context.Carts.Where(c => c.UserId == Convert.ToInt32(userId)
                                                     &&
                                                     c.CartStatusId == (int)CartStatus.Active)
                                            .FirstOrDefaultAsync();

            if (cart == null)
            {

                cart = new Cart();
                cart.UserId = Convert.ToInt32(userId);
                cart.TotalPrice = 0;
                cart.Expired = DateTime.Now.AddMonths(1);
                cart.CartStatusId = (int)CartStatus.Active;
                cart.Created = DateTime.Now;
                cart.Updated = DateTime.Now;

                await _context.Carts.AddAsync(cart);
                await _context.SaveChangesAsync();
            }


            var product = await _context.Products.Include(c=>c.ProductPhotos)
                                                        .Where(c=>c.Id == request.ProductId &&
                                                            c.ProductStatusId != (int)ProductStatus.Deactive)
                                                        .FirstOrDefaultAsync();  
            
            if(product == null)
                return ServiceResult<CartAddItemResponse>.ERROR("", "There is not any product like this.");



            var cartDetail = await _context.CartDetails.Where(c => c.CartId == cart.Id && c.ProductId == request.ProductId)
                                                            .FirstOrDefaultAsync();
            bool isExists = false;

            if(cartDetail == null)
            {
                cartDetail = new CartDetail();
                cartDetail.ProductId = product.Id;
                cartDetail.CartId = cart.Id;
                cartDetail.Count = request.Count;

                cartDetail.Price = product.Price; //todo: if discount then subtract
                cartDetail.TotalPrice = product.Discount != null ? ( (double)(product.Price - (product.Price*product.Discount/100)) * request.Count) : product.Price * request.Count;

                await _context.CartDetails.AddAsync(cartDetail);
                await _context.SaveChangesAsync();
            }

            else
            {
                isExists = true;
                cartDetail.Count += request.Count;
                cartDetail.TotalPrice += request.Count * product.Price;
            }


            cart.TotalPrice += cartDetail.TotalPrice;
            await _context.SaveChangesAsync();


            var response = new CartAddItemResponse();

            response.TotalPrice = cart.TotalPrice;
            response.ProductId = product.Id;
            response.Name = product.Name;
            response.Price = product.Price;
            response.Image = _configuration["Files:Products"] + product.ProductPhotos.Where(b => b.IsMain == true).Select(b => b.Image).FirstOrDefault();
            response.IsExists = isExists;
            return ServiceResult<CartAddItemResponse>.OK(response);

        }

        public async Task<ServiceResult<CartDeleteItemResponse>> DeleteItem(CartDeleteItemRequest request)
        {
            var userId = _httpContext.User.Claims.Where(c => c.Type == "Id").FirstOrDefault().Value;

            var cart = await _context.Carts.Include(c=>c.CartDetails).Where(c => c.UserId == Convert.ToInt32(userId)
                                                     &&
                                                     c.CartStatusId == (int)CartStatus.Active)
                                            .FirstOrDefaultAsync();
            if(cart == null)
                return ServiceResult<CartDeleteItemResponse>.ERROR("", "There is not any active cart in this user.");


            var cartDetail = cart.CartDetails.Where(c => c.ProductId == request.ProductId).FirstOrDefault();
            if(cartDetail == null)
                return ServiceResult<CartDeleteItemResponse>.ERROR("", "There is not any  cart detail in this user.");


            cart.TotalPrice -= cartDetail.TotalPrice;

            cart.CartDetails.Remove(cartDetail);

            var res = new CartDeleteItemResponse();
            res.Count = cartDetail.Count;
            res.TotalPrice = cart.TotalPrice;

            await _context.SaveChangesAsync();

            return ServiceResult<CartDeleteItemResponse>.OK(res);

        }

        public async Task<ServiceResult<GetCartItemsResponse>> GetCartItems()
        {
            var userId = _httpContext.User.Claims.Where(c => c.Type == "Id").FirstOrDefault().Value;

            var cart = await _context.Carts
                                        .Include(c => c.CartDetails)
                                        .ThenInclude(c => c.Product)
                                        .ThenInclude(c => c.ProductPhotos)
                                       .Where(c =>
                                       c.UserId == Convert.ToInt32(userId)
                                       &&
                                       c.CartStatusId == (int)CartStatus.Active)
                                       .Select(c => new CartDto
                                       {
                                           TotalPrice = c.TotalPrice,
                                           Count = c.CartDetails.Sum(a => a.Count),
                                           CartDetails = c.CartDetails.Select(a => new CartDetailDto
                                           {
                                               Name = a.Product.Name,
                                               ProductId = a.ProductId,
                                               AfterDiscountPrice = a.Product.Discount == null ? null : (a.Product.Price - (a.Product.Price * a.Product.Discount / 100)).ToString(),
                                               Image = _configuration["Files:Products"] + a.Product.ProductPhotos.Where(b => b.IsMain == true).Select(b => b.Image).FirstOrDefault()
                                               ,
                                               Price = a.Price,
                                               Count = a.Count
                                           }).ToList()

                                       }).FirstOrDefaultAsync();



            var res = new GetCartItemsResponse();

            if(cart == null)
            {
                res.Cart = new CartDto();
            }


            res.Cart = cart;

            return ServiceResult<GetCartItemsResponse>.OK(res);


        }
    }
}
