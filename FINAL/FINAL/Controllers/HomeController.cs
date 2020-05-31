using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using FINAL.Models;
using FINAL.Data;
using FINAL.ViewModels;

namespace FINAL.Controllers
{
    public class HomeController : BaseController
    {
        private readonly PropDbContext _context;
        private readonly ILogger<HomeController> _logger;
        public HomeController(ILogger<HomeController> logger, PropDbContext context) : base(context)
        {
            _context = context;
            _logger = logger;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult Contact()
        {
            HomeViewModel data = new HomeViewModel
            {
                Breadcumb = new BreadcumbViewModel
                {
                    Title = "Əlaqə",
                    Path = new List<BreadcumbItemViewModel>()
                }
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
            data.Breadcumb.Path.Add(home);
            data.Breadcumb.Path.Add(contact);
            ViewBag.Partial = data.Breadcumb;
            return View();
        }
    }
}
