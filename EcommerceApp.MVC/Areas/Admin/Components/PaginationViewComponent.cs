using System;
using EcommerceApp.MVC.Areas.Admin.Models;
using Microsoft.AspNetCore.Mvc;

namespace EcommerceApp.MVC.Areas.Admin.Components
{
    public class PaginationViewComponent : ViewComponent
    {
        public PaginationViewComponent()
        {
        }

        public async Task<IViewComponentResult> InvokeAsync(PaginationModel pageModel)
        {
            return View(pageModel);
        }
    }
}

