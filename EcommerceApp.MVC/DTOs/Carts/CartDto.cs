namespace EcommerceApp.MVC.DTOs.Carts
{
    public class CartDto
    {
        public double TotalPrice { get; set; } = 0;
        public int Count { get; set; } = 0;
        public List<CartDetailDto> CartDetails { get; set; } = new List<CartDetailDto>();
    }
}
