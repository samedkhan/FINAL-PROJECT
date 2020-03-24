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
                //ViewBag.IsCompany = usr.IsCompany;
                //ViewBag.FirstName = usr.FirstName;
                //ViewBag.LastName = usr.LastName;
                //ViewBag.Email = usr.Email;
                //ViewBag.Phone = usr.Phone;
                //ViewBag.Address = usr.Adress;
                //ViewBag.City = usr.City;
                //ViewBag.Zip = usr.ZipCode;
                //ViewBag.Country = usr.Country;
                //ViewBag.Image = usr.Image;
                //ViewBag.About = usr.AboutMe;
                //ViewBag.HasResume = usr.HasResume;
                //ViewBag.Facebook = usr.Facebook;
                //ViewBag.Google = usr.Google;
                //ViewBag.Since = usr.CreatedAt.ToString("MMMM yyyy");
                //ViewBag.HasResume = usr.HasResume;
            }

            base.OnActionExecuting(context);
        }
    }
}