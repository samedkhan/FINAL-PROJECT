using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FINAL.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using FINAL.Areas.Admin.Models;
using FINAL.Models;
using FINAL.Injections;

namespace FINAL.Areas.Admin.Controllers
{
    public class BaseController : Controller
    {
        private readonly PropDbContext _context;
        private readonly IAuth _auth;
        public BaseController(PropDbContext context, IAuth auth)
        {
            _context = context;
            _auth = auth;
        }

        public override void OnActionExecuting(ActionExecutingContext context)
        {
           
            
            var token = Request.Cookies["APtoken"];
            if (token != null)
            {
             
                ViewBag.User = _context.APusers.FirstOrDefault(u => u.Token == token);

            }

            ViewBag.AllUsersCount = _context.Users.ToList().Count();
            ViewBag.WaitingUsersCount = _context.Users.Where(u => u.Status == UserStatus.Waiting).ToList().Count();
            ViewBag.AgencyUsersCount = _context.Users.Where(u => u.UserTypeID == 1).ToList().Count();
            ViewBag.OwnerUsersCount = _context.Users.Where(u => u.UserTypeID == 2).ToList().Count();
            ViewBag.MediatorUsersCount = _context.Users.Where(u => u.UserTypeID == 3).ToList().Count();            

            ViewBag.AllAddsCount = _context.Addvertisiments.ToList().Count();
            ViewBag.ActiveAddsCount = _context.Addvertisiments.Where(a => a.AddStatus == AddStatus.Active && a.User.Status == UserStatus.Active).ToList().Count();
            ViewBag.WaitingAddsCount = _context.Addvertisiments.Where(a => a.AddStatus == AddStatus.Waiting && a.User.Status == UserStatus.Active).ToList().Count();
            ViewBag.DeactiveAddsCount = _context.Addvertisiments.Where(a => a.AddStatus == AddStatus.Deactive && a.User.Status == UserStatus.Active).ToList().Count();

            ViewBag.NewMessagesCount = _context.Messages.Where(m => m.HasReaded == false).ToList().Count();

            base.OnActionExecuting(context);
        }
    }
}