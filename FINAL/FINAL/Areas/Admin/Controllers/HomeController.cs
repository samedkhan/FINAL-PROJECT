using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using FINAL.Areas.Admin.ViewModels;
using FINAL.Data;
using FINAL.Injections;
using FINAL.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Http;

namespace FINAL.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class HomeController : BaseController
    {
        private readonly PropDbContext _context;
        private readonly IAuth _auth;
        private readonly Microsoft.AspNetCore.Hosting.IWebHostEnvironment _hosting;
        public HomeController(PropDbContext context, Microsoft.AspNetCore.Hosting.IWebHostEnvironment hosting, IAuth auth) : base(context, auth)
        {
            _context = context;
            _auth = auth;
            _hosting = hosting;
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

        [HttpPost]
        public IActionResult Editsettings(APSettingEditModel settingEdit)
        {
            string FileName;

            WebsiteSetting Selected = _context.WebsiteSettings.FirstOrDefault();

            if (ModelState.IsValid)
            {
                Selected.LocalAddress = settingEdit.LocalAddress;
                Selected.PhoneNumber = settingEdit.PhoneNumber;
                Selected.MobileNumber = settingEdit.PhoneNumber;
                Selected.Email = settingEdit.Email;
                Selected.FacebookAddress = settingEdit.FacebookAddress;
                Selected.LinkedinAddress = settingEdit.LinkedinAddress;
                Selected.TwitterAdress = settingEdit.TwitterAdress;

                if (settingEdit.Logo1 != null)
                {
                    string UploadsFolder = Path.Combine(_hosting.WebRootPath, "img", "logo");
                    FileName = Guid.NewGuid() + "_" + settingEdit.Logo1.FileName;
                    string FilePath = Path.Combine(UploadsFolder, FileName);
                    settingEdit.Logo1.CopyTo(new FileStream(FilePath, FileMode.Create));
                    Selected.MainLogo = FileName;
                }

                if (settingEdit.Logo2 != null)
                {
                    string UploadsFolder = Path.Combine(_hosting.WebRootPath, "img", "logo");
                    FileName = Guid.NewGuid() + "_" + settingEdit.Logo2.FileName;
                    string FilePath = Path.Combine(UploadsFolder, FileName);
                    settingEdit.Logo2.CopyTo(new FileStream(FilePath, FileMode.Create));
                    Selected.FooterLogo = FileName;
                }

                if (settingEdit.About != null)
                {
                    Selected.About = settingEdit.About;
                }

                _context.Entry(Selected).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                _context.SaveChanges();

                return RedirectToAction("Settings", "Home");
            }

            APHomeIndexViewModel data = new APHomeIndexViewModel
            {
                setting = Selected
            };

            return View("~/Areas/Admin/Views/Home/Editsettings.cshtml", data);

        }

        public IActionResult Users(int id)
        {

            return View();
        }
    }
}