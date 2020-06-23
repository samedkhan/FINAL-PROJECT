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
using MimeKit;
using MailKit.Net.Smtp;

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
       
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult Index()
        {
            //Checking Date of Creating Add for Deactivate
            foreach(Addvertisiment add in _context.Addvertisiments.ToList())
            {
                if(add.ExpDate < DateTime.Now)
                {
                    add.AddStatus = AddStatus.Deactive;
                    _context.SaveChanges();
                }
            }

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
                                                                                                         Where(a => a.User.Status == UserStatus.Active && a.AddStatus == AddStatus.Active).OrderByDescending(a => a.CreatedAt).ToList(),
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

        public IActionResult About()
        {
            HomeIndexViewModel data = new HomeIndexViewModel
            {
                About = new AboutIndexViewModel
                {
                    Setting = _context.WebsiteSettings.FirstOrDefault(),
                },
                Breadcumb = new BreadcumbViewModel
                {
                    Title = "Haqqımızda",
                    Path = new List<BreadcumbItemViewModel>()
                }
            };
            BreadcumbItemViewModel home = new BreadcumbItemViewModel
            {
                Name = "Ana səhifə",
                Controller = "Home",
                Action = "index"
            };
            BreadcumbItemViewModel about = new BreadcumbItemViewModel
            {
                Name = "Haqqımızda"
            };
            data.Breadcumb.Path.Add(home);
            data.Breadcumb.Path.Add(about);
            ViewBag.Partial = data.Breadcumb;
            return View(data);
        }

        public IActionResult Contact()
        {
            HomeIndexViewModel data = new HomeIndexViewModel
            {
                About = new AboutIndexViewModel
                {
                    Setting = _context.WebsiteSettings.FirstOrDefault(),
                },
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
            return View(data);
        }

        [HttpPost]
        public IActionResult SendMessage(SendMessagePostViewModel SendMessage)
        {
            if (ModelState.IsValid)
            {
                Message message = new Message
                {
                    Namesurname = SendMessage.Namesurname,
                    Text = SendMessage.Text,
                    Email = SendMessage.Email,
                    HasReaded = false,
                    CreatedAt = DateTime.Now
                };
                _context.Messages.Add(message);
                _context.SaveChanges();

                //SENDING EMAIL BY MailKit
                var textmessage = new MimeMessage();
                textmessage.From.Add(new MailboxAddress("From", "samed-khan@hotmail.com"));
                textmessage.To.Add(new MailboxAddress("To", "samadakh@code.edu.az"));
                textmessage.Subject = SendMessage.Namesurname + " / " + SendMessage.Email + " / " + DateTime.Now.ToString("dd/MM/yyyy HH:mm");

                textmessage.Body = new TextPart()
                {
                    Text = SendMessage.Text,
                };
                using (var client = new SmtpClient())
                {
                    client.Connect("smtp.live.com", 25, false);
                    client.Authenticate("samed-khan@hotmail.com", "passwordchangedbyme");
                    client.Send(textmessage);
                    client.Disconnect(true);
                }
                //END
                TempData["Success"] = "Mesajınız göndərildi...";
                return RedirectToAction("index", "home");
            }
            else
            {
                return Ok("BAD");
            }
        }
    }
}
