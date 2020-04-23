using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using FINAL.Models;

namespace FINAL.ViewModels
{
    public class AddIndexViewModel
    {
        public BreadcumbViewModel Breadcumb { get; set; }

        public AddCreateIndexViewModel AddCreateIndex { get; set; }

        public AddCreaterPostViewModel AddCreatePost { get; set; }
    }

    public class AddCreateIndexViewModel
    {
        public List<City> Cities { get; set; }

        public List<AddType> AddTypes { get; set; }

        public List<PropertySort> PropertySorts { get; set; }

        public List<Flat> Flats { get; set; }

        public List<Floor> Floors { get; set; }

        public List<PropDoc> PropDocs { get; set; }

        public List<Feature> Features { get; set; }
    }

    public class AddCreaterPostViewModel
    {
        [Required(ErrorMessage = "Qeyd edin")]
        public int AddTypeId { get; set; }

        [Required(ErrorMessage = "Qeyd edin")]
        public int PropertySortId { get; set; }

        [Required(ErrorMessage = "Qeyd edin")]
        public int CityId { get; set; }

        public int? DistrictId { get; set; }

        [Required(ErrorMessage = "Daxil edin")]
        public string PropertyFullAddress { get; set; }

        public int? FloorSum { get; set; }

        public int? FloorId { get; set; }

        public int? FlatId { get; set; }

        public int PropDocId { get; set; }

        [Required]
        public decimal BuildingVolume { get; set; }

        public decimal? LandVolume { get; set; }

        [Required(ErrorMessage = "Əmlak haqqında ətraflı yazın")]
        public string FullAbout { get; set; }

        [Required(ErrorMessage = "Daxil edin")]
        public decimal AddPrice { get; set; }

        public float? Longitude { get; set; }

        public float? Latitude { get; set; }

        public List<PropFeature> Features { get; set; }
    }
}
