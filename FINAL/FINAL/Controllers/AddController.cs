using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FINAL.Data;
using FINAL.Injections;
using FINAL.Models;
using FINAL.ViewModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;

namespace FINAL.Controllers
{
    public class AddController : BaseController
    {
        private readonly PropDbContext _context;
        private readonly IAuth _auth;

        public AddController(PropDbContext context, IAuth auth) : base(context)
        {
            _context = context;
            _auth = auth;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Create()
        {
            var token = Request.Cookies["token"];

            if (token == null)
            {
                return RedirectToAction("login", "account");
            }
            else
            {
                AddIndexViewModel data = new AddIndexViewModel
                {
                    Breadcumb = new BreadcumbViewModel
                    {
                        Title = "Elan yerləşdir",
                        Path = new List<BreadcumbItemViewModel>()
                    },
                    
                   
                };
                BreadcumbItemViewModel home = new BreadcumbItemViewModel
                {
                    Name = "Ana səhifə",
                    Controller = "Home",
                    Action = "index"
                };

                BreadcumbItemViewModel create = new BreadcumbItemViewModel
                {
                    Name = "Elan yerləşdirmə"
                };

                data.Breadcumb.Path.Add(home);
                data.Breadcumb.Path.Add(create);

                ViewBag.Partial = data.Breadcumb;

                List<City> Cities = _context.Cities.Include(c=>c.Districts).ToList();
                 
                ViewBag.Cities = Cities;

                return View();
            }
            
        }

        public IActionResult GetDistricts(int id)
        {
            List<District> districts = _context.Districts.Where(d => d.CityID == id).ToList();

            return Ok(
                districts.Select(d => new
                {
                    d.DistrictId,
                    d.DistrictName
                }));
        }

        public IActionResult GetGeoInfo(int id)
        {
            City SelectedCity = _context.Cities.Where(c => c.CityId == id).FirstOrDefault();

            return Ok(
                new
                {
                    SelectedCity.Latitude,
                    SelectedCity.Longitude
                }
                
                );
        }


        public IActionResult Detail(int id)
        {
            //Addvertisiment Add = _context.PropAdds.Include(a => a.User).Include(a => a.PropPhotos).Include(a => a.City).Include(a => a.District).Include(a => a.PropertySort).Where(a => a.PropAddId == id).FirstOrDefault();

            //if (Add == null)
            //{
            //    return NotFound();
            //}
            //else
            //{
            //    AddIndexViewModel data = new AddIndexViewModel
            //    {
            //        Breadcumb = new BreadcumbViewModel
            //        {
            //            Title = "Elan haqqında",
            //            Path = new List<BreadcumbItemViewModel>()
            //        }
            //    };

            //    BreadcumbItemViewModel home = new BreadcumbItemViewModel
            //    {
            //        Name = "Ana səhifə",
            //        Controller = "Home",
            //        Action = "index"
            //    };

            //    BreadcumbItemViewModel adds = new BreadcumbItemViewModel
            //    {
            //        Name = "Bütün elanlar",
            //        Controller = "Add",
            //        Action = "index"
            //    };

            //    BreadcumbItemViewModel detail = new BreadcumbItemViewModel
            //    {
            //        Name = "Elan haqqında"
            //    };

            //    data.Breadcumb.Path.Add(home);
            //    data.Breadcumb.Path.Add(adds);
            //    data.Breadcumb.Path.Add(detail);

            //    ViewBag.Partial = data.Breadcumb;

            //}
                return View();

        }
    }
}