using System;
using System.Collections.Generic;
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
    }

    public class AboutIndexViewModel
    {
        public WebsiteSetting Setting { get; set; }
    }
}
