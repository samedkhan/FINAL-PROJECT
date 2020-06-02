using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using FINAL.Models;
using FINAL.Data;
using FINAL.ViewModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;

namespace FINAL.Controllers
{
    public class HomeController : BaseController
    {
        private readonly PropDbContext _context;
        private readonly ILogger<HomeController> _logger;
        public HomeController(ILogger<HomeController> logger, PropDbContext context) : base(context)
        {
            _context = context;
            _logger = logger;
        }
        public IActionResult Index()
        {
            HomeIndexViewModel data = new HomeIndexViewModel
            {
                AddsPanel = new AddsPanelViewModel
                {
                    Type = ViewType.normal,
                    AddList = _context.Addvertisiments.Include("AddType").Include("Property").
                                                                            Include("Property.City").
                                                                                Include("Property.District").
                                                                                    Include("Property.Flat").
                                                                                        Include("Property.Floor").
                                                                                            Include("Property.PropDoc").
                                                                                                Include("Property.PropertySort").
                                                                                                    Include("Property.Project").
                                                                                                         Where(a => a.User.Status == UserStatus.Active && a.AddStatus == AddStatus.Active).OrderByDescending(a => a.CreatedAt).Take(12).ToList(),
                },
                SearchPanel = new FilterPanelViewModel
                {
                    AddTypes = _context.AddTypes.ToList(),
                    Cities = _context.Cities.ToList(),
                    PropertySorts = _context.PropertySorts.ToList(),
                },
                Agencies = _context.Users.Where(u => u.UserTypeID == 1 && u.Status == UserStatus.Active).ToList(),
            };
            ViewBag.Adds = data.AddsPanel;
            return View(data);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult Contact()
        {
            HomeIndexViewModel data = new HomeIndexViewModel
            {
                Breadcumb = new BreadcumbViewModel
                {
                    Title = "Əlaqə",
                    Path = new List<BreadcumbItemViewModel>()
                }
            };          
            BreadcumbItemViewModel home = new BreadcumbItemViewModel
            {
                Name = "Ana səhifə",
                Controller = "Home",
                Action = "index"
            };
            BreadcumbItemViewModel contact = new BreadcumbItemViewModel
            {
                Name = "Əlaqə"
            };
            data.Breadcumb.Path.Add(home);
            data.Breadcumb.Path.Add(contact);
            ViewBag.Partial = data.Breadcumb;
            return View();
        }
    }
}
