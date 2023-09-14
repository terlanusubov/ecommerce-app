using EcommerceApp.MVC.Core;
using EcommerceApp.MVC.Core.Requests;
using EcommerceApp.MVC.Core.Responses;

namespace EcommerceApp.MVC.Interfaces
{
    public interface ICartService
    {
        Task<ServiceResult<GetCartItemsResponse>> GetCartItems();
        Task<ServiceResult<CartDeleteItemResponse>> DeleteItem(CartDeleteItemRequest request);
        Task<ServiceResult<CartAddItemResponse>> AddItem(CartAddItemRequest request);
    }
}
