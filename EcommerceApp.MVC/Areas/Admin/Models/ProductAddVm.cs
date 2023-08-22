using System;
using EcommerceApp.MVC.Areas.Admin.DTOs;
using EcommerceApp.MVC.DTOs.Categories;

namespace EcommerceApp.MVC.Areas.Admin.Models
{
    public class ProductAddVm
    {
        public List<BrandDto> Brands { get; set; }
        public List<SizeDto> Sizes { get; set; }
        public List<CategoryListDto> Categories { get; set; }
        public List<ColorDto> Colors { get; set; }


        public ProductAddModel Product { get; set; }
    }
}

