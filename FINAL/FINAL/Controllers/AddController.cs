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
                return RedirectToAction("index", "account");
            }
            else
            {
                AddIndexViewModel data = new AddIndexViewModel
                {
                    AddCreateIndex = new AddCreateIndexViewModel {
                        Cities = _context.Cities.Include(c => c.Districts).ToList(),
                        PropertySorts = _context.PropertySorts.OrderBy(ps => ps.PropertySortId).ToList(),
                        AddTypes = _context.AddTypes.OrderBy(ad => ad.AddTypeId).ToList(),
                        Flats = _context.Flats.OrderBy(f => f.FlatID).ToList(),
                        Floors = _context.Floors.OrderBy(f => f.FloorID).ToList(),
                        PropDocs = _context.PropDocs.OrderBy(ps => ps.PropDocID).ToList(),
                        Features = _context.Features.OrderBy(f => f.FeatureID).ToList()
                    },
                  
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


                return View(data);
            }
            
        }

        public IActionResult GetProjects(int id)
        {
            List<PropProject> projects = _context.PropProjects.Where(pp => pp.PropertySortId == id).ToList();

            return Ok(
               projects.Select(p => new
               {
                   p.PropProjectID,
                   p.PropProjectName
               }));
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


        //public IActionResult Detail(int id)
        //{
        //    //Addvertisiment Add = _context.PropAdds.Include(a => a.User).Include(a => a.PropPhotos).Include(a => a.City).Include(a => a.District).Include(a => a.PropertySort).Where(a => a.PropAddId == id).FirstOrDefault();

        //    //if (Add == null)
        //    //{
        //    //    return NotFound();
        //    //}
        //    //else
        //    //{
        //    //    AddIndexViewModel data = new AddIndexViewModel
        //    //    {
        //    //        Breadcumb = new BreadcumbViewModel
        //    //        {
        //    //            Title = "Elan haqqında",
        //    //            Path = new List<BreadcumbItemViewModel>()
        //    //        }
        //    //    };

        //    //    BreadcumbItemViewModel home = new BreadcumbItemViewModel
        //    //    {
        //    //        Name = "Ana səhifə",
        //    //        Controller = "Home",
        //    //        Action = "index"
        //    //    };

        //    //    BreadcumbItemViewModel adds = new BreadcumbItemViewModel
        //    //    {
        //    //        Name = "Bütün elanlar",
        //    //        Controller = "Add",
        //    //        Action = "index"
        //    //    };

        //    //    BreadcumbItemViewModel detail = new BreadcumbItemViewModel
        //    //    {
        //    //        Name = "Elan haqqında"
        //    //    };

        //    //    data.Breadcumb.Path.Add(home);
        //    //    data.Breadcumb.Path.Add(adds);
        //    //    data.Breadcumb.Path.Add(detail);

        //    //    ViewBag.Partial = data.Breadcumb;

        //    //}
        //        return View();

        //}


        public IActionResult Deactivate(int id)
        {
            var token = Request.Cookies["token"];

            if (token == null)
            {
                return RedirectToAction("index", "account");
            }

            Addvertisiment SelectedAdd = _context.Addvertisiments.Include("User").Where(a => a.AddvertisimentID == id && a.UserId == _auth.User.UserId).FirstOrDefault();

            if(SelectedAdd == null)
            {
                return BadRequest();
            }

            SelectedAdd.AddStatus = AddStatus.Deactive;

            _context.Entry(SelectedAdd).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _context.SaveChanges();

            //return RedirectToAction("index", "cabinet", new { id = _auth.User.UserId });

            List<Addvertisiment> DeactivatedAdds = _context.Addvertisiments.Where(a => a.AddStatus == AddStatus.Deactive).ToList();
            int DeactivatedAddsCount = DeactivatedAdds.Count();
           
            List<Addvertisiment> ActivedAdds = _context.Addvertisiments.Where(a => a.AddStatus == AddStatus.Active).ToList();
            int ActiveAddsCount = ActivedAdds.Count();
            
            List<Addvertisiment> WaitingdAdds = _context.Addvertisiments.Where(a => a.AddStatus == AddStatus.Waiting).ToList();
            int WaitingAddsCount = WaitingdAdds.Count();

            List<Addvertisiment> RentAdds = _context.Addvertisiments.Where(a => a.AddStatus == AddStatus.Active && a.AddTypeID<3).ToList();
            int RentAddsCount = RentAdds.Count();

            List<Addvertisiment> SaleAdds = _context.Addvertisiments.Where(a => a.AddStatus == AddStatus.Active && a.AddTypeID == 3).ToList();
            int SaleAddsCount = SaleAdds.Count();

            return Ok(
                new
                {
                    DeactivatedAddsCount,
                    ActiveAddsCount,
                    WaitingAddsCount,
                    RentAddsCount,
                    SaleAddsCount
                });
        }

        public IActionResult Remove(int id)
        {
            var token = Request.Cookies["token"];

            if (token == null)
            {
                return RedirectToAction("index", "account");
            }

            Addvertisiment SelectedAdd = _context.Addvertisiments.Include("User").Where(a => a.AddvertisimentID == id && a.UserId == _auth.User.UserId).FirstOrDefault();

            if (SelectedAdd == null)
            {
                return BadRequest();
            }

            SelectedAdd.AddStatus = AddStatus.Hidden;

            _context.Entry(SelectedAdd).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _context.SaveChanges();

            List<Addvertisiment> DeactivatedAdds = _context.Addvertisiments.Where(a => a.AddStatus == AddStatus.Deactive).ToList();
            List<Addvertisiment> AllAdds = _context.Addvertisiments.Where(a => a.AddStatus != AddStatus.Hidden).ToList();

            int DeactivatedAddsCount = DeactivatedAdds.Count();
            int AllAddsCount = AllAdds.Count();
           
            return Ok(
                new
                {
                    DeactivatedAddsCount,
                    AllAddsCount
                }
                );
        }
    }
}