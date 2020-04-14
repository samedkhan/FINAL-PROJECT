﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using FINAL.ViewModels;
using FINAL.Models;
using FINAL.Data;
using CryptoHelper;
using Microsoft.EntityFrameworkCore;
using FINAL.Injections;
using System.IO;

namespace FINAL.Controllers
{
    
    public class AccountController : BaseController
    {

        private readonly PropDbContext _context;
        private readonly IAuth _auth;
        private readonly Microsoft.AspNetCore.Hosting.IWebHostEnvironment _hosting;

        public AccountController(PropDbContext context, Microsoft.AspNetCore.Hosting.IWebHostEnvironment hosting, IAuth auth):base(context)
        {
            _context = context;
            _auth = auth;
            _hosting = hosting;
        }

        public IActionResult Index()
        {
            AccountIndexViewModel data = new AccountIndexViewModel()
            {
                Breadcumb = new BreadcumbViewModel
                {
                    Title = "Şəxsi kabinetə giriş",
                    Path = new List<BreadcumbItemViewModel>()
                },
            };

            BreadcumbItemViewModel home = new BreadcumbItemViewModel
            {
                Name = "Ana səhifə",
                Controller = "Home",
                Action = "index"
            };
            BreadcumbItemViewModel logSign = new BreadcumbItemViewModel
            {
                Name = "Daxil Ol - Qeydiyyat"
            };
            data.Breadcumb.Path.Add(home);
            data.Breadcumb.Path.Add(logSign);
            ViewBag.Partial = data.Breadcumb;
            ViewBag.UserTypes = _context.UserTypes.OrderBy(u => u.UserTypeId).ToList();


            return View();
        }


        [HttpPost]
        public IActionResult Login(AccountLoginModel Login)
        {
            if (ModelState.IsValid)
            {
                User user = _context.Users.Where(u => u.Email == Login.Email).FirstOrDefault();

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
                Title = "Şəxsi kabinetə giriş",
                Path = new List<BreadcumbItemViewModel>()
            };
            BreadcumbItemViewModel home = new BreadcumbItemViewModel
            {
                Name = "Ana səhifə",
                Controller = "Home",
                Action = "index"
            };
            BreadcumbItemViewModel logSign = new BreadcumbItemViewModel
            {
                Name = "Daxil Ol - Qeydiyyat"
            };
            data.Breadcumb.Path.Add(home);
            data.Breadcumb.Path.Add(logSign);
            ViewBag.Partial = data.Breadcumb;
            ViewBag.UserTypes = _context.UserTypes.OrderBy(u => u.UserTypeId).ToList();
            return View("~/Views/Account/Index.cshtml");
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
                        UserTypeID = register.UserTypeId,
                        PhoneNumber = register.PhoneNumber,
                        CreatedAt = DateTime.Now
                    };


                    if (register.UserTypeId > 1)
                    {
                        NewUser.Surname = register.Surname;
                    }

                    _context.Users.Add(NewUser);
                    _context.SaveChanges();

                    Response.Cookies.Append("token", NewUser.Token, new Microsoft.AspNetCore.Http.CookieOptions
                    {
                        Expires = DateTime.Now.AddYears(1),
                        HttpOnly = true
                    });
                    return RedirectToAction("settings", "account", new { id = NewUser.UserId });
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
                Title = "Şəxsi kabinetə giriş",
                Path = new List<BreadcumbItemViewModel>()
            };
            BreadcumbItemViewModel home = new BreadcumbItemViewModel
            {
                Name = "Ana səhifə",
                Controller = "Home",
                Action = "index"
            };
            BreadcumbItemViewModel logSign = new BreadcumbItemViewModel
            {
                Name = "Daxil Ol - Qeydiyyat"
            };
            data.Breadcumb.Path.Add(home);
            data.Breadcumb.Path.Add(logSign);
            ViewBag.Partial = data.Breadcumb;
            ViewBag.UserTypes = _context.UserTypes.OrderBy(u => u.UserTypeId).ToList();
            return View("~/Views/Account/Index.cshtml");
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

        public IActionResult Settings(int id)
        {
            var token = Request.Cookies["token"];
            
            if(token == null)
            {
                return RedirectToAction("login", "account");
            }

            User LoggedUser = _context.Users.Include(u=>u.UserType).Where(u=>u.UserId==id).FirstOrDefault();

            if (LoggedUser == null)
            {
                return NotFound();
            }

            if(LoggedUser.Token != token)
            {
                return BadRequest();
            }

            AccountIndexViewModel data = new AccountIndexViewModel
            {
                Breadcumb = new BreadcumbViewModel
                {
                    Title = "Tənzimləmələr",
                    Path = new List<BreadcumbItemViewModel>()
                },
                
            };
            BreadcumbItemViewModel home = new BreadcumbItemViewModel
            {
                Name = "Ana səhifə",
                Controller = "Home",
                Action = "index"
            };
            BreadcumbItemViewModel settings = new BreadcumbItemViewModel
            {
                Name = "Tənzimləmələr"
            };
            data.Breadcumb.Path.Add(home);
            data.Breadcumb.Path.Add(settings);
            ViewBag.Partial = data.Breadcumb;

            ViewBag.User = LoggedUser;
            return View();
        }

        [HttpPost]
        public IActionResult Settings(AccountSettingModel setting)
        {

            if (ModelState.IsValid)
            {
                var token = Request.Cookies["token"];
                string FileName = null;
                User LoggedUser = _context.Users.Find(_auth.User.UserId);
                if(LoggedUser.Token != token)
                {
                    return BadRequest();
                }

                LoggedUser.Name = setting.Name;
                LoggedUser.PhoneNumber = setting.PhoneNumber;

                if (LoggedUser.UserTypeID > 1) // if user type is ev sahibi or makler
                {
                    LoggedUser.Surname = setting.Surname;
                }

                if (LoggedUser.UserTypeID == 1) //if usertype is Agentlik
                {

                    LoggedUser.Adress = setting.Adress;
                    LoggedUser.AboutCompany = setting.AboutCompany;
                }

                if (setting.Photo != null)
                {
                    string UploadsFolder = Path.Combine(_hosting.WebRootPath, "img", "users");
                    FileName = Guid.NewGuid() + "_" + setting.Photo.FileName;
                    string FilePath = Path.Combine(UploadsFolder, FileName);
                    setting.Photo.CopyTo(new FileStream(FilePath, FileMode.Create));
                    LoggedUser.Logo = FileName;
                }

                _context.Entry(LoggedUser).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                _context.SaveChanges();

                return RedirectToAction("index", "home");
            }
          
            AccountIndexViewModel data = new AccountIndexViewModel
            {
                Setting = setting,
                Breadcumb = new BreadcumbViewModel
                {
                    Title = "Tənzimləmələr",
                    Path = new List<BreadcumbItemViewModel>()
                }

            };
            BreadcumbItemViewModel home = new BreadcumbItemViewModel
            {
                Name = "Ana səhifə",
                Controller = "Home",
                Action = "index"
            };
            BreadcumbItemViewModel settings = new BreadcumbItemViewModel
            {
                Name = "Tənzimləmələr"
            };
            data.Breadcumb.Path.Add(home);
            data.Breadcumb.Path.Add(settings);

            ViewBag.Partial = data.Breadcumb;
            return View("~/Views/Account/Profile.cshtml");
        }
    }
}