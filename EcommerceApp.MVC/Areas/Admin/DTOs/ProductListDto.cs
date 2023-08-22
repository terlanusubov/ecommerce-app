using System;
namespace EcommerceApp.MVC.Areas.Admin.DTOs
{
    public class ProductListDto
    {
        public int ProductId { get; set; }
        public float Price { get; set; }
        public int? Discount { get; set; }
        public string Image { get; set; }
        public DateTime? Created { get; set; }
        public int ProductStatusId { get; set; }
        public string CategoryName { get; set; }
        public string Name { get; set; }
    }
}

