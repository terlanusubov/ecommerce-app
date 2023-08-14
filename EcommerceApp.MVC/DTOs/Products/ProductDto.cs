namespace EcommerceApp.MVC.DTOs.Products
{
    public class ProductDto
    {
        public string MainImage { get; set; }
        public List<string> Images { get; set; }
        public string CategoryName { get; set; }
        public string Price { get; set; }
        public string AfterDiscountPrice { get; set; }
        public string Name { get; set; }
        public int ProductId { get; set; }
    }
}
