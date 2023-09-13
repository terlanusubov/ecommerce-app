using EcommerceApp.MVC.Core.Requests;
using EcommerceApp.MVC.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace EcommerceApp.MVC.Controllers
{
    //TODO: Add authorization
    public class CartController : Controller
    {

        private readonly ICartService _cartService;
        public CartController(ICartService cartService)
        {
            _cartService = cartService;
        }

        [HttpPost]
        public async Task<JsonResult> Add([FromBody]CartAddItemRequest request)
        {
            //TODO: Validation

            var response = await _cartService.AddItem(request);

            if(response==null || response.Status != 200)
            {
                return Json(new
                {
                    status = 400,
                    error = response.Errors.FirstOrDefault().Value
                });
            }

            return Json(new { status = 200, data = response.Response});
        }

       [HttpGet]
        public async Task<JsonResult> Delete([FromQuery]CartDeleteItemRequest request)
        {

            var response = await _cartService.DeleteItem(request);

            if (response == null || response.Status != 200)
            {
                return Json(new
                {
                    status = 400,
                    error = response.Errors.FirstOrDefault().Value
                });
            }

            return Json(new { status = 200 ,data = response.Response});

        }
    }
}
