using System;
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
            BreadcumbItemViewModel login = new BreadcumbItemViewModel
            {
                Name = "Daxil Ol"
            };
            data.Breadcumb.Path.Add(home);
            data.Breadcumb.Path.Add(login);
            ViewBag.Partial = data.Breadcumb;
            return View();
        }
        public IActionResult Signup()
        {
            AccountIndexViewModel data = new AccountIndexViewModel()
            {
                Breadcumb = new BreadcumbViewModel
                {
                    Title = "Yeni üzv",
                    Path = new List<BreadcumbItemViewModel>()
                },
            };

            BreadcumbItemViewModel home = new BreadcumbItemViewModel
            {
                Name = "Ana səhifə",
                Controller = "Home",
                Action = "index"
            };
            BreadcumbItemViewModel signup = new BreadcumbItemViewModel
            {
                Name = "Qeydiyyat"
            };
            data.Breadcumb.Path.Add(home);
            data.Breadcumb.Path.Add(signup);
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
                        TempData["Success"] = "Sistemə müvəffəqiyyətlə daxil oldunuz...";
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
            BreadcumbItemViewModel login = new BreadcumbItemViewModel
            {
                Name = "Daxil Ol"
            };
            data.Breadcumb.Path.Add(home);
            data.Breadcumb.Path.Add(login);
            ViewBag.Partial = data.Breadcumb;
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
                        CreatedAt = DateTime.Now,
                        Status = UserStatus.Waiting,
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
                    return RedirectToAction("settings", "account");
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
                Title = "Yeni üzv",
                Path = new List<BreadcumbItemViewModel>()
            };
            BreadcumbItemViewModel home = new BreadcumbItemViewModel
            {
                Name = "Ana səhifə",
                Controller = "Home",
                Action = "index"
            };
            BreadcumbItemViewModel signup = new BreadcumbItemViewModel
            {
                Name = "Qeydiyyat"
            };
            data.Breadcumb.Path.Add(home);
            data.Breadcumb.Path.Add(signup);
            ViewBag.Partial = data.Breadcumb;
            ViewBag.UserTypes = _context.UserTypes.OrderBy(u => u.UserTypeId).ToList();
            return View("~/Views/Account/Signup.cshtml");
        }

        public IActionResult Logout()
        {
            if(_auth.User == null)
            {
                return RedirectToAction("index", "account");
            }

            _auth.User.Token = null;
            _context.SaveChanges();

            Response.Cookies.Append("token", Request.Cookies["token"], new Microsoft.AspNetCore.Http.CookieOptions
            {
                Expires = DateTime.Now.AddDays(-1),
                HttpOnly = true
            });
            TempData["Success"] = "Sistemdən müvəffəqiyyətlə çıxış etdiniz...";
            return RedirectToAction("index", "home");

        }

        public IActionResult Settings()
        {
            var token = Request.Cookies["token"];
            
            if(token == null)
            {
                return RedirectToAction("index", "account");
            }


            if (_auth.User == null)
            {
                return NotFound();
            }

            if(_auth.User.Token != token)
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

            ViewBag.User = _auth.User;
            return View();
        }

        [HttpPost]
        public IActionResult Settings(AccountSettingModel setting)
        {
            var token = Request.Cookies["token"];

            User LoggedUser = _auth.User;

            if (LoggedUser.Token != token)
            {
                return BadRequest();
            }

            string FileName;

            if (ModelState.IsValid)
            {
                
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
                TempData["Success"] = "Məlumatlar müvəffəqiyyətlə daxil etdiniz, yoxlandıqdan sonra yayımlanacaq...";
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

        public IActionResult Cabinet()
        {
            string Token = Request.Cookies["token"];

            if (Token == null)
            {
                return RedirectToAction("index", "account");
            }
            else
            {
                User LoginedUser = _context.Users.Where(u => u.Token == Token && u.UserId == _auth.User.UserId).FirstOrDefault();

                if (LoginedUser == null)
                {
                    return BadRequest();
                }
                else
                {

                    List<Addvertisiment> allAdds = _context.Addvertisiments.Include("User").Include("Property").Include("Property.City").Include("Property.District").Include("Property.PropertySort").Where(a => a.UserId == _auth.User.UserId && a.AddStatus != AddStatus.Hidden).OrderByDescending(a => a.CreatedAt).ToList();

                    List<Addvertisiment> activeAdds = _context.Addvertisiments.Include("User").Include("Property").Include("Property.City").Include("Property.District").Include("Property.PropertySort").Where(a => a.UserId == _auth.User.UserId && a.AddStatus == AddStatus.Active).OrderByDescending(a => a.CreatedAt).ToList();

                    List<Addvertisiment> deactiveAdds = _context.Addvertisiments.Include("User").Include("Property").Include("Property.City").Include("Property.District").Include("Property.PropertySort").Where(a => a.UserId == _auth.User.UserId && a.AddStatus == AddStatus.Deactive).OrderByDescending(a => a.CreatedAt).ToList();

                    List<Addvertisiment> waitingAdds = _context.Addvertisiments.Include("User").Include("Property").Include("Property.City").Include("Property.District").Include("Property.PropertySort").Where(a => a.UserId == _auth.User.UserId && a.AddStatus == AddStatus.Waiting).OrderByDescending(a => a.CreatedAt).ToList();

                    List<Addvertisiment> rentAdds = _context.Addvertisiments.Include("User").Include("Property").Include("Property.City").Include("Property.District").Include("Property.PropertySort").Where(a => a.UserId == _auth.User.UserId && a.AddTypeID < 3 && a.AddStatus == AddStatus.Active).OrderByDescending(a => a.CreatedAt).ToList();

                    List<Addvertisiment> saleAdds = _context.Addvertisiments.Include("User").Include("Property").Include("Property.City").Include("Property.District").Include("Property.PropertySort").Where(a => a.UserId == _auth.User.UserId && a.AddTypeID == 3 && a.AddStatus == AddStatus.Active).OrderByDescending(a => a.CreatedAt).ToList();

                    AccountIndexViewModel data = new AccountIndexViewModel
                    {
                        Cabinet = new AccountCabinetModel
                        {
                            AllAdds = allAdds,
                            ActiveAdds = activeAdds,
                            DeactiveAdds = deactiveAdds,
                            WaitingAdds = waitingAdds,
                            RentAdds = rentAdds,
                            SaleAdds = saleAdds,
                        },


                        Breadcumb = new BreadcumbViewModel
                        {
                            Title = "Şəxsi kabinet",
                            Path = new List<BreadcumbItemViewModel>()
                        }
                    };


                    BreadcumbItemViewModel home = new BreadcumbItemViewModel
                    {
                        Name = "Ana səhifə",
                        Controller = "Home",
                        Action = "index"
                    };
                    BreadcumbItemViewModel cab = new BreadcumbItemViewModel
                    {
                        Name = "Şəxsi kabinet"
                    };
                    data.Breadcumb.Path.Add(home);
                    data.Breadcumb.Path.Add(cab);
                    ViewBag.Partial = data.Breadcumb;
                    return View(data);
                }
            }
        }


    }
}