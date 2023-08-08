using System;
namespace EcommerceApp.MVC.Models
{
    public class Slider
    {
        public int Id { get; set; }
        public string BackgroundImage { get; set; }
        public string TopImage { get; set; }
        public string BottomImage { get; set; }
        public string Title { get; set; }
        public string Slogan { get; set; }
        public int CategoryId { get; set; }

        public virtual Category Category { get; set; }
    }
}

