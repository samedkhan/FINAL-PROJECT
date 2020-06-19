using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using FINAL.Areas.Admin.ViewModels;
using FINAL.Data;
using FINAL.Injections;
using FINAL.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace FINAL.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class HomeController : BaseController
    {
        private readonly PropDbContext _context;
        private readonly IAuth _auth;
        public HomeController(PropDbContext context, IAuth auth) : base(context, auth)
        {
            _context = context;
            _auth = auth;
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

        public IActionResult Index()
        {
           
            if (_auth.APuser == null)
            {
                return RedirectToAction("Login", "Account");
            }

            return View();
        }

        public IActionResult Settings()
        {
            if (_auth.APuser == null)
            {
                return RedirectToAction("Login", "Account");
            }

            if(_auth.APuser.isAdmin != true)
            {
                return BadRequest();
            }

            APHomeIndexViewModel data = new APHomeIndexViewModel
            {
                setting = _context.WebsiteSettings.FirstOrDefault()
            };

            return View(data);
        }

        public IActionResult Editsettings()
        {
            if (_auth.APuser == null)
            {
                return RedirectToAction("Login", "Account");
            }

            if (_auth.APuser.isAdmin != true)
            {
                return BadRequest();
            }

            APHomeIndexViewModel data = new APHomeIndexViewModel
            {
                setting = _context.WebsiteSettings.FirstOrDefault()
            };

            return View(data);
        }
        public IActionResult Users(int id)
        {

            return View();
        }
    }
}