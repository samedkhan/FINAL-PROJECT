using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FINAL.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using FINAL.Areas.Admin.Models;
using FINAL.Models;

namespace FINAL.Areas.Admin.Controllers
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
            var token = Request.Cookies["APtoken"];
            if (token != null)
            {
             
                ViewBag.User = _context.APusers.FirstOrDefault(u => u.Token == token);
            }

            ViewBag.UserTypes = _context.UserTypes.ToList();

            base.OnActionExecuting(context);
        }
    }
}