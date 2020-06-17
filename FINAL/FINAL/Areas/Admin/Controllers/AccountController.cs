using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CryptoHelper;
using FINAL.Areas.Admin.Models;
using FINAL.Areas.Admin.ViewModels;
using FINAL.Data;
using FINAL.Injections;
using Microsoft.AspNetCore.Mvc;

namespace FINAL.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AccountController : BaseController
    {
        private readonly PropDbContext _context;
        private readonly Microsoft.AspNetCore.Hosting.IWebHostEnvironment _hosting;

        public AccountController(PropDbContext context, Microsoft.AspNetCore.Hosting.IWebHostEnvironment hosting) : base(context)
        {
            _context = context;
            _hosting = hosting;
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(APAccountLoginModel Login)
        {
            if (ModelState.IsValid)
            {
                APuser user = _context.APusers.Where(u => u.Email == Login.Email).FirstOrDefault();

                if (user != null)
                {
                    if (Crypto.VerifyHashedPassword(user.Password, Login.Password))
                    {
                        user.Token = Guid.NewGuid().ToString();
                        _context.SaveChanges();

                        Response.Cookies.Append("APtoken", user.Token, new Microsoft.AspNetCore.Http.CookieOptions
                        {
                            Expires = DateTime.Now.AddHours(1),
                            HttpOnly = true
                        });
                        return RedirectToAction("index", "home");
                    }
                    else
                    {
                        ModelState.AddModelError("Login.Password", "E-poçt və ya şifrə yalnışdır");
                    }
                }
                else
                {
                    ModelState.AddModelError("Login.Password", "E-poçt və ya şifrə yalnışdır");
                }
            }
           
            return View("~/Areas/Admin/Views/Account/Login.cshtml");
        }

        public IActionResult Logout()
        {
            var token = Request.Cookies["APtoken"];

            if (token == null)
            {
                return RedirectToAction("Login", "Account");
            }

            APuser user = _context.APusers.Where(u => u.Token == token).FirstOrDefault();
            user.Token = null;
            _context.SaveChanges();

            Response.Cookies.Append("APtoken", Request.Cookies["APtoken"], new Microsoft.AspNetCore.Http.CookieOptions
            {
                Expires = DateTime.Now.AddDays(-1),
                HttpOnly = true
            });

            return RedirectToAction("Login", "Account");

        }
    }
}