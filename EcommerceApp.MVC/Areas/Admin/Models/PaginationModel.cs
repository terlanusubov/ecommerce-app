using System;
namespace EcommerceApp.MVC.Areas.Admin.Models
{
    public class PaginationModel
    {
        public string Url { get; set; }
        public decimal Count { get; set; }
        public int Page { get; set; }
    }
}

