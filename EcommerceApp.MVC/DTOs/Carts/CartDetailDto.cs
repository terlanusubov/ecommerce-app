namespace EcommerceApp.MVC.DTOs.Carts
{
    public class CartDetailDto
    {
        public string Image { get; set; }
        public int? Discount { get; set; }
        public string AfterDiscountPrice { get; set; }
        public int ProductId { get; set; }

        public double Price { get; set; }
        public string Name { get; set; }
    }
}
