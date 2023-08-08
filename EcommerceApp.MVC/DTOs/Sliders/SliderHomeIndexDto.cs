using System;
using EcommerceApp.MVC.Models;

namespace EcommerceApp.MVC.DTOs.Sliders
{
    public class SliderHomeIndexDto
    {
        public string BackgroundImage { get; set; }
        public string TopImage { get; set; }
        public string BottomImage { get; set; }
        public string Title { get; set; }
        public string Slogan { get; set; }
        public int CategoryId { get; set; }
    }
}

