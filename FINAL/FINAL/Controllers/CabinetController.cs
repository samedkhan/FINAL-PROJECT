using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FINAL.Data;
using FINAL.Injections;
using FINAL.Models;
using FINAL.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FINAL.Controllers
{
    public class CabinetController : BaseController
    {


        private readonly PropDbContext _context;
        private readonly IAuth _auth;

        public CabinetController(PropDbContext context, IAuth auth) : base(context)
        {
            _context = context;
            _auth = auth;
        }

        public IActionResult Index(int id)
        {
            string Token = Request.Cookies["token"];
            
            if (Token == null)
            {
                return RedirectToAction("login", "account");
            }
            else
            {
                User LoginedUser = _context.Users.Where(u => u.Token == Token && u.UserId == id).FirstOrDefault();
                
                if (LoginedUser == null)
                {
                    return BadRequest();
                }
                else
                {

                    List<Addvertisiment> allAdds = _context.Addvertisiments.Include("User").Include("Property").Include("Property.City").Include("Property.District").Include("Property.PropertySort").Where(a => a.UserId == id && a.AddStatus != AddStatus.Hidden).OrderByDescending(a => a.CreatedAt).ToList();
                
                    List<Addvertisiment> activeAdds = _context.Addvertisiments.Include("User").Include("Property").Include("Property.City").Include("Property.District").Include("Property.PropertySort").Where(a => a.UserId == id && a.AddStatus == AddStatus.Active).OrderByDescending(a => a.CreatedAt).ToList();
                    
                    List<Addvertisiment> deactiveAdds = _context.Addvertisiments.Include("User").Include("Property").Include("Property.City").Include("Property.District").Include("Property.PropertySort").Where(a => a.UserId == id && a.AddStatus == AddStatus.Deactive).OrderByDescending(a => a.CreatedAt).ToList();
                    
                    List<Addvertisiment> waitingAdds = _context.Addvertisiments.Include("User").Include("Property").Include("Property.City").Include("Property.District").Include("Property.PropertySort").Where(a => a.UserId == id && a.AddStatus == AddStatus.Waiting).OrderByDescending(a => a.CreatedAt).ToList();
                    
                    List<Addvertisiment> rentAdds = _context.Addvertisiments.Include("User").Include("Property").Include("Property.City").Include("Property.District").Include("Property.PropertySort").Where(a => a.UserId == id && a.AddTypeID<3 && a.AddStatus == AddStatus.Active ).OrderByDescending(a => a.CreatedAt).ToList();
                    
                    List<Addvertisiment> saleAdds = _context.Addvertisiments.Include("User").Include("Property").Include("Property.City").Include("Property.District").Include("Property.PropertySort").Where(a => a.UserId == id && a.AddTypeID==3 && a.AddStatus == AddStatus.Active).OrderByDescending(a => a.CreatedAt).ToList();

                    CabinetIndexViewModel data = new CabinetIndexViewModel
                    {
                        AllAdds = allAdds,
                        ActiveAdds = activeAdds,
                        DeactiveAdds = deactiveAdds,
                        WaitingAdds = waitingAdds,
                        RentAdds = rentAdds,
                        SaleAdds = saleAdds,

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