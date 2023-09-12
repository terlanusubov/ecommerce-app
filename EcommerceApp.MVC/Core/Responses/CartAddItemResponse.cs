namespace EcommerceApp.MVC.Core.Responses
{
    public class CartAddItemResponse
    {
        public double TotalPrice { get; set; }
        public int ProductId { get; set; }
        public double Price { get; set; }
        public string Image { get; set; }
        public string Name { get; set; }

        public bool IsExists { get; set; }
    }
}
