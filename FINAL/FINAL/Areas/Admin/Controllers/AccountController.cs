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
        private readonly IAuth _auth;

        public AccountController(PropDbContext context, Microsoft.AspNetCore.Hosting.IWebHostEnvironment hosting, IAuth auth) : base(context)
        {
            _context = context;
            _hosting = hosting;
            _auth = auth;
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

            if (_auth.APuser == null)
            {
                return BadRequest();
            }

            _auth.APuser.Token = null;
            _context.SaveChanges();

            Response.Cookies.Append("APtoken", Request.Cookies["APtoken"], new Microsoft.AspNetCore.Http.CookieOptions
            {
                Expires = DateTime.Now.AddDays(-1),
                HttpOnly = true
            });

            return RedirectToAction("Login", "Account");

        }

        public IActionResult APUsers()
        {

            if (_auth.APuser == null || _auth.APuser.isSuperAdmin == false)
            {
                return RedirectToAction("Login", "Account");
            }

            APAccountIndexViewModel data = new APAccountIndexViewModel
            {
                APUsers = _context.APusers.Where(apu=>apu.isSuperAdmin==false).ToList()
            };

            return View(data);
        }

        public IActionResult Create()
        {

            if (_auth.APuser == null || _auth.APuser.isAdmin == false)
            {
                return BadRequest();
            }

            
            return View();
        }

        [HttpPost]
        public IActionResult Create(APAccountCreateModel Create)
        {
            if (ModelState.IsValid)
            {
                if (!_context.APusers.Any(u => u.Email == Create.Email))
                {
                    APuser NewUser = new APuser
                    {
                        Nickname = Create.Name,
                        Email = Create.Email,
                        Password = Crypto.HashPassword(Create.Password),
                        Token = null,
                        isAdmin = Create.isAdmin
                    };

                    _context.APusers.Add(NewUser);
                    _context.SaveChanges();

                    return RedirectToAction("APUsers", "Account");
                }
                else
                {
                    ModelState.AddModelError("Create.Email", "E-Poçt ünvanı artıq mövcuddur");
                }
            }
            return View("~/Areas/Admin/Views/Account/Create.cshtml");
        }

        public IActionResult Edit(int id)
        {
            APuser SelectedUser = _context.APusers.Find(id);

            if (_auth.APuser == null || _auth.APuser.isSuperAdmin == false || SelectedUser == null)
            {
                return BadRequest();
            }

            APAccountIndexViewModel data = new APAccountIndexViewModel
            {
                SelectedUser = SelectedUser
            };

            return View(data);
        }

        [HttpPost]
        public IActionResult Edit(APAccountEditModel Edit)
        {
            APuser SelectedUser = _context.APusers.Where(apu => apu.Email == Edit.Email).FirstOrDefault();

            if (ModelState.IsValid)
            {
               
                SelectedUser.isAdmin = Edit.isAdmin;
                SelectedUser.Nickname = Edit.Name;
                SelectedUser.Password = Crypto.HashPassword(Edit.Password);
                SelectedUser.Token = null;

                _context.Entry(SelectedUser).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                _context.SaveChanges();

                return RedirectToAction("APUsers", "Account");
            }

            APAccountIndexViewModel data = new APAccountIndexViewModel
            {
                SelectedUser = SelectedUser
            };

            return View("~/Areas/Admin/Views/Account/Edit.cshtml", data);
        }

        public IActionResult Delete(int id)
        {
            APuser SelectedUser = _context.APusers.Find(id);

            if (_auth.APuser == null || _auth.APuser.isSuperAdmin == false || SelectedUser == null)
            {
                return BadRequest();
            }

            _context.APusers.Remove(SelectedUser);
            _context.SaveChanges();

            return RedirectToAction("APUsers", "Account");

        }
    }
}