using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using FINAL.Areas.Admin.ViewModels;
using FINAL.Data;
using FINAL.Injections;
using FINAL.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FINAL.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class UserController : BaseController
    {
        private readonly PropDbContext _context;
        private readonly IAuth _auth;
        private readonly Microsoft.AspNetCore.Hosting.IWebHostEnvironment _hosting;

        public UserController(PropDbContext context, IAuth auth, Microsoft.AspNetCore.Hosting.IWebHostEnvironment hosting) : base(context, auth)
        {
            _context = context;
            _auth = auth;
            _hosting = hosting;
        }

        public IActionResult Index()
        {
            if (_auth.APuser == null)
            {
                return RedirectToAction("Login", "Account");
            }

            APUserIndexViewModel data = new APUserIndexViewModel
            {
                Users = _context.Users.Include("UserType").Include("Adds").OrderByDescending(u => u.CreatedAt).ToList()
            };

            return View(data);
        }

        public IActionResult Approve(int id)
        {
            if (_auth.APuser == null)
            {
                return RedirectToAction("Login", "Account");
            }

            User SelectedUser = _context.Users.Find(id);

            if (SelectedUser == null)
            {
                return NotFound();
            }

            SelectedUser.Status = UserStatus.Active;
            _context.SaveChanges();

            return RedirectToAction("index", "User");
        }

        public IActionResult Deactivate(int id)
        {
            if (_auth.APuser == null)
            {
                return RedirectToAction("Login", "Account");
            }

            User SelectedUser = _context.Users.Find(id);

            if (SelectedUser == null || _auth.APuser.isSuperAdmin == false)
            {
                return NotFound();
            }

            SelectedUser.Status = UserStatus.Deactive;
            _context.SaveChanges();

            return RedirectToAction("index", "user");
        }

        public IActionResult Remove(int id)
        {
            if (_auth.APuser == null)
            {
                return RedirectToAction("Login", "Account");
            }

            User SelectedUser = _context.Users.Find(id);

            if (SelectedUser == null || _auth.APuser.isSuperAdmin == false)
            {
                return NotFound();
            }


            string FilePath = Path.Combine(_hosting.WebRootPath, "img", "users", SelectedUser.Logo);

            if (System.IO.File.Exists(FilePath))
            {
                try
                {
                    System.IO.File.Delete(FilePath);
                }
                catch (Exception)
                {
                    return RedirectToAction("index", "user");
                }
            }

            List<Addvertisiment> SelectedUserAdds = _context.Addvertisiments.Where(a => a.UserId == SelectedUser.UserId).ToList();

            foreach(Addvertisiment add in SelectedUserAdds)
            {
                Property AddProp = _context.Properties.Find(add.PropertyID);

                List<PropPhoto> AddPropPhotos = _context.PropPhotos.Where(p => p.PropertyId == add.PropertyID).ToList();

                foreach (PropPhoto item in AddPropPhotos)
                {
                    FilePath = Path.Combine(_hosting.WebRootPath, "img", "property", item.PropPhotoName);
                    
                    _context.PropPhotos.Remove(item);

                    if (System.IO.File.Exists(FilePath))
                    {
                        try
                        {
                            System.IO.File.Delete(FilePath);
                        }
                        catch (Exception)
                        {
                            return RedirectToAction("index", "user");
                        }
                    }

                    _context.Properties.Remove(AddProp);
                    _context.Addvertisiments.Remove(add);
                }
            }
            _context.Users.Remove(SelectedUser);
            _context.SaveChanges();

            Response.Cookies.Append("token", Request.Cookies["token"], new Microsoft.AspNetCore.Http.CookieOptions
            {
                Expires = DateTime.Now.AddDays(-1),
                HttpOnly = true
            });

            return RedirectToAction("index", "user");
        }
    }
}