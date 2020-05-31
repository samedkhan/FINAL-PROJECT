using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using FINAL.Models;

namespace FINAL.ViewModels
{
    public class FilterPanelViewModel
    {
        public List<AddType> AddTypes { get; set; }

        public List<City> Cities { get; set; }

        public List<PropertySort> PropertySorts { get; set; }

        public AddSearchGetViewModel SearchGet { get; set; }
    }

    public class AddSearchGetViewModel
    {
       
        public int? AddTypeId { get; set; }

        public int? CityId { get; set; }

        public int? DistrictId { get; set; }

        public int? PropertySortId { get; set; }

        public int? ProjectId { get; set; }


    }
}
