using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


namespace EcommerceApp.MVC.Areas.Admin.Controllers
{
    [Area("admin")]
    [Authorize]
    public class ProductController : Controller
    {
        public IActionResult List()
        {
            return View();
        }
    }
}

