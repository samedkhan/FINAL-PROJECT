using FINAL.Models;
using System.Collections.Generic;

namespace FINAL.ViewModels
{
    public class AgencyViewModel
    {
        public BreadcumbViewModel Breadcumb { get; set; }
        public OwnerPanelViewModel Owner { get; set; }
        public AddsPanelViewModel AddsPanel { get; set; }
        public AgencyIndexViewModel Agencies { get; set; }
    }

    public class AgencyIndexViewModel
    {
        public List<User> Users { get; set; }
    }


}
