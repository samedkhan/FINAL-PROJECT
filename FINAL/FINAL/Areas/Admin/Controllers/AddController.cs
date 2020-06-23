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
using static System.Net.Mime.MediaTypeNames;

namespace FINAL.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AddController : BaseController
    {
        private readonly PropDbContext _context;
        private readonly IAuth _auth;
        private readonly Microsoft.AspNetCore.Hosting.IWebHostEnvironment _hosting;

        public AddController(PropDbContext context, IAuth auth, Microsoft.AspNetCore.Hosting.IWebHostEnvironment hosting) : base(context, auth)
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


            APAddIndexViewModel data = new APAddIndexViewModel
            {
                adds = _context.Addvertisiments.Include("User").Include("AddType").Include("Property").
                                                                            Include("Property.City").
                                                                                Include("Property.District").
                                                                                    Include("Property.Flat").
                                                                                        Include("Property.Floor").
                                                                                            Include("Property.PropDoc").
                                                                                                Include("Property.PropertySort").
                                                                                                    Include("Property.Project").Where(a=> a.User.Status == UserStatus.Active).OrderByDescending(a => a.CreatedAt).ToList()
            };
           
            return View(data);
        }

        public IActionResult Deactivate(int id)
        {
            if (_auth.APuser == null)
            {
                return RedirectToAction("Login", "Account");
            }

            Addvertisiment SelectedAdd = _context.Addvertisiments.Find(id);

            if(SelectedAdd == null || _auth.APuser.isAdmin == false)
            {
                return NotFound();
            }

            SelectedAdd.AddStatus = AddStatus.Deactive;
            _context.SaveChanges();

            return RedirectToAction("index", "Add");
        }

        public IActionResult Remove(int id)
        {
            if (_auth.APuser == null)
            {
                return RedirectToAction("Login", "Account");
            }

            Addvertisiment SelectedAdd = _context.Addvertisiments.Find(id);

            if (SelectedAdd == null || _auth.APuser.isSuperAdmin == false)
            {
                return NotFound();
            }

            List<PropPhoto> propPhotos = _context.PropPhotos.Where(p => p.PropertyId == SelectedAdd.PropertyID).ToList();
            

            foreach (PropPhoto item in propPhotos)
            {
                string FilePath = Path.Combine(_hosting.WebRootPath, "img", "property", item.PropPhotoName);
                _context.PropPhotos.Remove(item);

                if (System.IO.File.Exists(FilePath))
                {
                    try
                    {
                        System.IO.File.Delete(FilePath);
                    }
                    catch (Exception)
                    {
                        return RedirectToAction("index", "Add");
                    }
                }

                
            }

            Property prop = _context.Properties.Find(SelectedAdd.PropertyID);
            _context.Properties.Remove(prop);


            _context.Addvertisiments.Remove(SelectedAdd);

            _context.SaveChanges();

            return RedirectToAction("index", "Add");
        }

        public IActionResult Approve(int id)
        {
            if (_auth.APuser == null)
            {
                return RedirectToAction("Login", "Account");
            }

            Addvertisiment SelectedAdd = _context.Addvertisiments.Find(id);

            if (SelectedAdd == null)
            {
                return NotFound();
            }

            SelectedAdd.AddStatus = AddStatus.Active;
            _context.SaveChanges();

            return RedirectToAction("index", "Add");
        }
    }
}