using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace FINAL.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            var token = Request.Cookies["token"];

            if (token == null)
            {
                return RedirectToAction("index", "account");
            }

            return View();
        }

    }
}