using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FINAL.Data;
using FINAL.Models;
using FINAL.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Rejoin.Injections;

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

                    List<PropAdd> AllAdds = _context.PropAdds.Include(a => a.User).Where(a => a.UserId == id && (a.AddStatus != AddStatus.Hidden || a.AddStatus != AddStatus.Deactive)).ToList();
                    List<PropAdd> ActiveAdds = _context.PropAdds.Include(a => a.User).Include(a => a.City).Include(a => a.District).Include(a => a.PropertySort).Where(a => a.UserId == id && a.AddStatus == AddStatus.Active).OrderByDescending(a => a.CreatedAt).ToList();
                    List<PropAdd> DeactiveAdds = _context.PropAdds.Include(a => a.User).Include(a => a.City).Include(a => a.District).Include(a => a.PropertySort).Where(a => a.UserId == id && a.AddStatus == AddStatus.Deactive).OrderByDescending(a => a.CreatedAt).ToList();
                    List<PropAdd> WaitingAdds = _context.PropAdds.Include(a => a.User).Include(a => a.City).Include(a => a.District).Include(a => a.PropertySort).Where(a => a.UserId == id && a.AddStatus == AddStatus.Waiting).OrderByDescending(a => a.CreatedAt).ToList();
                    List<PropAdd> RentAdds = _context.PropAdds.Include(a => a.User).Include(a => a.City).Include(a => a.District).Include(a => a.PropertySort).Where(a => a.UserId == id && (a.AddType == AddType.KirayeAyliq || a.AddType == AddType.KirayeGunluk) && a.AddStatus == AddStatus.Active).OrderByDescending(a => a.CreatedAt).ToList();
                    List<PropAdd> SaleAdds = _context.PropAdds.Include(a => a.User).Include(a => a.City).Include(a => a.District).Include(a => a.PropertySort).Where(a => a.UserId == id && a.AddType == AddType.Satilir && a.AddStatus == AddStatus.Active).OrderByDescending(a => a.CreatedAt).ToList();

                    CabinetIndexViewModel data = new CabinetIndexViewModel
                    {
                        Breadcumb = new BreadcumbViewModel
                        {
                            Title = "Şəxsi kabinet",
                            Path = new List<BreadcumbItemViewModel>()
                        }
                    };

                    ViewBag.AllAdds = AllAdds;
                    ViewBag.Active = ActiveAdds;
                    ViewBag.Deactive = DeactiveAdds;
                    ViewBag.Waiting = WaitingAdds;
                    ViewBag.Rent = RentAdds;
                    ViewBag.Sale = SaleAdds;

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
                    return View();
                }
            }
        }
    }
}