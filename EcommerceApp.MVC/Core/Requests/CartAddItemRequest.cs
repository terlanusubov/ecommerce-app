namespace EcommerceApp.MVC.Core.Requests
{
    public class CartAddItemRequest
    {
        public int ProductId { get; set; }
        public int Count { get; set; }
    }
}
