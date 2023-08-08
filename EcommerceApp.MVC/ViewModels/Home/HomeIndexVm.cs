﻿using System;
using EcommerceApp.MVC.DTOs.BannerAds;
using EcommerceApp.MVC.DTOs.Sliders;

namespace EcommerceApp.MVC.ViewModels.Home
{
    public class HomeIndexVm
    {
        public List<SliderHomeIndexDto> Sliders { get; set; }
        public List<BannerHomeIndexDto> BannerAds { get; set; }
    }
}
