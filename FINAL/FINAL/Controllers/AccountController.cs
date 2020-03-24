using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using FINAL.ViewModels;
using FINAL.Models;
using FINAL.Data;
using CryptoHelper;
using Rejoin.Injections;
using Microsoft.EntityFrameworkCore;

namespace FINAL.Controllers
{
    
    public class AccountController : BaseController
    {

        private readonly PropDbContext _context;
        private readonly IAuth _auth;

        public AccountController(PropDbContext context, IAuth auth):base(context)
        {
            _context = context;
            _auth = auth;
        }

        public IActionResult Login()
        {
            AccountIndexViewModel data = new AccountIndexViewModel();

            data.Breadcumb = new BreadcumbViewModel
            {
                Title = "Daxil ol",
                Path = new List<BreadcumbItemViewModel>()
            };
            BreadcumbItemViewModel home = new BreadcumbItemViewModel
            {
                Name = "Ana səhifə",
                Controller = "Home",
                Action = "index"
            };
            BreadcumbItemViewModel log = new BreadcumbItemViewModel
            {
                Name = "Daxil ol"
            };
            data.Breadcumb.Path.Add(home);
            data.Breadcumb.Path.Add(log);
            ViewBag.Partial = data.Breadcumb;
            return View();
        }

        [HttpPost]
        public IActionResult Login(AccountLoginModel Login)
        {
            if (ModelState.IsValid)
            {
                User user = _context.Users.Where(u => u.Email == Login.Email).FirstOrDefault();

                //return Ok(ModelState);
                if (user != null)
                {
                    if (Crypto.VerifyHashedPassword(user.Password, Login.Password))
                    {
                        user.Token = Guid.NewGuid().ToString();
                        _context.SaveChanges();

                        Response.Cookies.Append("token", user.Token, new Microsoft.AspNetCore.Http.CookieOptions
                        {
                            Expires = DateTime.Now.AddYears(1),
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
            AccountIndexViewModel data = new AccountIndexViewModel
            {
                Login = Login
            };
            data.Breadcumb = new BreadcumbViewModel
            {
                Title = "Daxil ol",
                Path = new List<BreadcumbItemViewModel>()
            };
            BreadcumbItemViewModel home = new BreadcumbItemViewModel
            {
                Name = "Ana səhifə",
                Controller = "Home",
                Action = "index"
            };
            BreadcumbItemViewModel log = new BreadcumbItemViewModel
            {
                Name = "Daxil ol"
            };
            data.Breadcumb.Path.Add(home);
            data.Breadcumb.Path.Add(log);
            ViewBag.Partial = data.Breadcumb;
            return View("~/Views/Account/Login.cshtml");
        }


        public IActionResult Register()
        {
            AccountIndexViewModel data = new AccountIndexViewModel();

            data.Breadcumb = new BreadcumbViewModel
            {
                Title = "Qeydiyyat",
                Path = new List<BreadcumbItemViewModel>()
            };
            BreadcumbItemViewModel home = new BreadcumbItemViewModel
            {
                Name = "Ana səhifə",
                Controller = "Home",
                Action = "index"
            };
            BreadcumbItemViewModel reg = new BreadcumbItemViewModel
            {
                Name = "Qeydiyyat"
            };
            data.Breadcumb.Path.Add(home);
            data.Breadcumb.Path.Add(reg);
            ViewBag.Partial = data.Breadcumb;
            return View();
        }

        [HttpPost]
        public IActionResult Register(AccountRegisterModel register)
        {
            if (ModelState.IsValid)
            {
                if (!_context.Users.Any(u => u.Email == register.Email))
                {
                    User NewUser = new User
                    {
                        Name = register.Name,
                        Email = register.Email,
                        Password = Crypto.HashPassword(register.Password),
                        Token = Guid.NewGuid().ToString(),
                        UserType = register.Type,
                        CreatedAt = DateTime.Now
                    };


                    if (register.Type != UserType.Agentlik)
                    {
                        if(string.IsNullOrEmpty(register.Surname))
                        {
                            ModelState.AddModelError("Register.Surname", "Soyadınızı daxil edin");
                        }
                        else
                        {
                            NewUser.Surname = register.Surname;
                        }
                    }

                    if (ModelState.IsValid)
                    {
                        _context.Users.Add(NewUser);
                        _context.SaveChanges();

                        Response.Cookies.Append("token", NewUser.Token, new Microsoft.AspNetCore.Http.CookieOptions
                        {
                            Expires = DateTime.Now.AddYears(1),
                            HttpOnly = true
                        });

                        return RedirectToAction("index", "home");
                    }
                }
                else
                {
                    ModelState.AddModelError("Register.Email", "E-Poçt ünvanı artıq registrasiyadan keçib");
                }
                
            }
            AccountIndexViewModel data = new AccountIndexViewModel
            {
                Register = register
            };
            data.Breadcumb = new BreadcumbViewModel
            {
                Title = "Qeydiyyat",
                Path = new List<BreadcumbItemViewModel>()
            };
            BreadcumbItemViewModel home = new BreadcumbItemViewModel
            {
                Name = "Ana səhifə",
                Controller = "Home",
                Action = "index"
            };
            BreadcumbItemViewModel reg = new BreadcumbItemViewModel
            {
                Name = "Qeydiyyat"
            };
            data.Breadcumb.Path.Add(home);
            data.Breadcumb.Path.Add(reg);
            ViewBag.Partial = data.Breadcumb;
            return View("~/Views/Account/Register.cshtml");
        }

        public IActionResult Logout()
        {
            var token = Request.Cookies["token"];
            User LoggedUser = _context.Users.Find(_auth.User.UserId);
            LoggedUser.Token = null;
            _context.SaveChanges();
            Response.Cookies.Append("token", token, new Microsoft.AspNetCore.Http.CookieOptions
            {
                Expires = DateTime.Now.AddDays(-1),
                HttpOnly = true
            });
            return RedirectToAction("index", "home");
        }

       
    }
}