using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using FINAL.Models;

namespace FINAL.ViewModels
{
    public class HomeIndexViewModel
    {
        public BreadcumbViewModel Breadcumb { get; set; }
        public AddsPanelViewModel AddsPanel { get; set; }

        public FilterPanelViewModel SearchPanel { get; set; }

        public AddSearchGetViewModel SearchGet { get; set; }

        public List<User> Agencies { get; set; }

        public AboutIndexViewModel About { get; set; }

        public SendMessagePostViewModel SendMessage { get; set; }
    }

    public class AboutIndexViewModel
    {
        public WebsiteSetting Setting { get; set; }
    }

    public class SendMessagePostViewModel
    {
        public string Namesurname { get; set; }

        public string Email { get; set; }

        public string Text { get; set; }


    }
}
