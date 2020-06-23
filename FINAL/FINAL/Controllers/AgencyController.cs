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
    public class AgencyController : BaseController
    {
        private readonly PropDbContext _context;
        private readonly IAuth _auth;
        private readonly Microsoft.AspNetCore.Hosting.IWebHostEnvironment _hosting;

        public AgencyController(PropDbContext context, Microsoft.AspNetCore.Hosting.IWebHostEnvironment hosting, IAuth auth) : base(context)
        {
            _context = context;
            _auth = auth;
            _hosting = hosting;
        }

        public IActionResult Index()
        {

            AgencyViewModel data = new AgencyViewModel
            {
                Agencies = new AgencyIndexViewModel
                {
                    Users = _context.Users.Include("Adds").Where(u => u.UserTypeID == 1 && u.Status == UserStatus.Active && u.Adds.Count() > 0).ToList(),
                },
                Breadcumb = new BreadcumbViewModel
                {
                    Title = "Agentliklər",
                    Path = new List<BreadcumbItemViewModel>()
                },
            };
            BreadcumbItemViewModel home = new BreadcumbItemViewModel
            {
                Name = "Ana səhifə",
                Controller = "Home",
                Action = "index"
            };
            BreadcumbItemViewModel Agencies = new BreadcumbItemViewModel
            {
                Name = "Agentliklər"
            };
            data.Breadcumb.Path.Add(home);
            data.Breadcumb.Path.Add(Agencies);
            ViewBag.Partial = data.Breadcumb;
            return View(data);
        }

        public IActionResult Detail(int id)
        {
            User selectedUser = _context.Users.Include("Adds").Where(u => u.UserId == id).FirstOrDefault();

            if (selectedUser == null || selectedUser.UserTypeID > 1 && _auth.APuser == null) //Dont show Owners and Mediators to Users and Quests
            {
                return NotFound();
            }

            AgencyViewModel data = new AgencyViewModel
            {
                Owner = new OwnerPanelViewModel
                {
                    Owner = selectedUser,
                    OwnerActiveAdds = _context.Addvertisiments.Where(a => a.UserId == id && a.AddStatus == AddStatus.Active).Count()
                },
                Breadcumb = new BreadcumbViewModel
                {
                    Title = "Agentliyin elanları",
                    Path = new List<BreadcumbItemViewModel>()
                },
                AddsPanel = new AddsPanelViewModel
                {
                    Type = ViewType.small,
                    AddList = _context.Addvertisiments.Include("Property").
                                                                            Include("Property.City").
                                                                                Include("Property.District").
                                                                                    Include("Property.Flat").
                                                                                        Include("Property.Floor").
                                                                                            Include("Property.PropDoc").
                                                                                                Include("Property.PropertySort").
                                                                                                    Include("Property.Project").
                                                                                                        Where(a => a.UserId == id && a.AddStatus == AddStatus.Active).
                                                                                                            OrderByDescending(a => a.CreatedAt).ToList(),
                }

            };
            BreadcumbItemViewModel home = new BreadcumbItemViewModel
            {
                Name = "Ana səhifə",
                Controller = "Home",
                Action = "index"
            };

            BreadcumbItemViewModel Agencies = new BreadcumbItemViewModel
            {
                Name = "Agentliklər",
                Controller = "Agency",
                Action = "index"
            };

            BreadcumbItemViewModel AgencyDetail = new BreadcumbItemViewModel {
                Name = selectedUser.Name,
            };

            data.Breadcumb.Path.Add(home);
            data.Breadcumb.Path.Add(Agencies);
            data.Breadcumb.Path.Add(AgencyDetail);
            ViewBag.Partial = data.Breadcumb;
            ViewBag.Owner = data.Owner;
            ViewBag.Adds = data.AddsPanel;
            ViewBag.AddsCount = data.AddsPanel.AddList.Count();
            return View();
        }
    }
}