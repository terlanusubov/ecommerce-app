using System;
namespace EcommerceApp.MVC.Areas.Admin.Models
{
    public class ProductAddModel
    {
        public string Name { get; set; }
        public int CategoryId { get; set; }
        public int BrandId { get; set; }
        public int ColorId { get; set; }
        public int SizeId { get; set; }
        public float Price { get; set; }
        public int? Discount { get; set; }
        public string ShortDesc { get; set; }
        public string Description { get; set; }
        public int StatusId { get; set; }
        public int StockCount { get; set; }

        public IFormFile MainImage { get; set; }
        public List<IFormFile> Images { get; set; }
    }
}

