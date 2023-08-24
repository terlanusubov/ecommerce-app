using System;
using System.ComponentModel.DataAnnotations;

namespace EcommerceApp.MVC.Areas.Admin.Models
{
    public class ProductAddModel
    {
        [Required]
        public string Name { get; set; }
        [Required]

        public int CategoryId { get; set; }
        [Required]

        public int BrandId { get; set; }
        [Required]

        public int ColorId { get; set; }
        [Required]

        public int SizeId { get; set; }
        [Required]

        public float Price { get; set; }

        public int? Discount { get; set; }

        [Required]

        public string ShortDesc { get; set; }
        [Required]

        public string Description { get; set; }
        [Required]

        public int StatusId { get; set; }
        [Required]

        public int StockCount { get; set; }

        [Required]

        public IFormFile MainImage { get; set; }
        [Required]

        public List<IFormFile> Images { get; set; }
    }
}

