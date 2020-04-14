using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FINAL.Models;

namespace FINAL.ViewModels
{
    public class AddIndexViewModel
    {
        public BreadcumbViewModel Breadcumb { get; set; }

        public List<City> Cities { get; set; }
    }
}
