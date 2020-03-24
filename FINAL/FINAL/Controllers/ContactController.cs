using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using FINAL.ViewModels;

namespace FINAL.Controllers
{
    public class ContactController : Controller
    {
        public IActionResult Index()
        {
            BreadcumbViewModel breadcumb = new BreadcumbViewModel
            {
                Title = "Əlaqə",
                Path = new List<BreadcumbItemViewModel>()
            };
            BreadcumbItemViewModel home = new BreadcumbItemViewModel
            {
                Name = "Ana səhifə",
                Controller = "Home",
                Action = "index"
            };
            BreadcumbItemViewModel contact = new BreadcumbItemViewModel
            {
                Name = "Əlaqə"
            };
            breadcumb.Path.Add(home);
            breadcumb.Path.Add(contact);
            ViewBag.Partial = breadcumb;
            return View();
        }
    }
}