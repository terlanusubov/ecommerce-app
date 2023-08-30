namespace EcommerceApp.MVC.DTOs.Products
{
    public class ProductDto
    {
        public string MainImage { get; set; }
        public List<string> Images { get; set; } = new List<string>();
        public string CategoryName { get; set; }
        public string Price { get; set; }
        public string AfterDiscountPrice { get; set; }
        public string Name { get; set; }
        public int ProductId { get; set; }
        public string MainCode { get; set; }
        public string BrandName { get; set; }
        public bool HasStock { get; set; }
        public string ShortDesc { get; set; }
        public string Description { get; set; }
        public string ProductCode { get; set; }
        public List<IGrouping<string, ProductColorDto>> Colors { get; set; } = new List<IGrouping<string, ProductColorDto>>();


        public List<IGrouping<string, ProductSizeDto>> Sizes { get; set; } = new List<IGrouping<string, ProductSizeDto>>();
    }
}
