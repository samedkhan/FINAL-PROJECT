using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FINAL.Data;
using FINAL.Models;
using Microsoft.AspNetCore.Mvc.Filters;

namespace FINAL.Controllers
{
    public class BaseController : Controller
    {
        private readonly PropDbContext _context;
        public BaseController(PropDbContext context)
        {
            _context = context;
        }

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            var token = Request.Cookies["token"];
            if (token != null)
            {
                User usr = _context.Users.FirstOrDefault(u => u.Token == token);
                ViewBag.User = usr;
                ViewBag.UserName = usr.Name + " " + usr.Surname;
                ViewBag.UserId = usr.UserId;
            }

            ViewBag.PropertySorts = _context.PropertySorts.OrderBy(ps => ps.PropertySortId).ToList();
            
            ViewBag.Setting = _context.WebsiteSettings.FirstOrDefault();

            base.OnActionExecuting(context);
        }
    }
}