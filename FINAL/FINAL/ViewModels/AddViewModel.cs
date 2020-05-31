using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using FINAL.Models;
using Microsoft.AspNetCore.Http;

namespace FINAL.ViewModels
{
    public class AddViewModel
    {
        public BreadcumbViewModel Breadcumb { get; set; }

        public OwnerPanelViewModel Owner { get; set; }

        public AddsPanelViewModel AddsPanel { get; set; }

        public FilterPanelViewModel FilterPanel { get; set; }

        public AddCreateIndexViewModel AddCreateIndex { get; set; }

        public AddCreatePostViewModel AddCreatePost { get; set; }

        public AddDetailIndexViewModel AddDetailIndex { get; set; }

        
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


    public class AddCreatePostViewModel
    {
        [Required]
        public int AddTypeId { get; set; }

        [Required(ErrorMessage = "Qeyd edin")]
        public int PropertySortId { get; set; }

        [Required(ErrorMessage = "Qeyd edin")]
        public int CityId { get; set; }

        public int? DistrictId { get; set; }

        [Required(ErrorMessage = "Daxil edin")]
        public string PropertyFullAddress { get; set; }

        public float? Longitude { get; set; }

        public float? Latitude { get; set; }

        public int? ProjectId { get; set; }

        public int? FloorSum { get; set; }

        public int? FloorId { get; set; }

        public int? FlatId { get; set; }

        public int PropDocId { get; set; }

        public decimal? BuildingVolume { get; set; }

        public decimal? LandVolume { get; set; }

        [Required(ErrorMessage = "Əmlak haqqında ətraflı yazın")]
        public string FullAbout { get; set; }

        public List<Feature> Features { get; set; }

        [Required(ErrorMessage = "Daxil edin")]
        public decimal AddPrice { get; set; }

        public List<IFormFile> Photos { get; set; }
    }


    public class AddDetailIndexViewModel
    {
        public Addvertisiment Add { get; set; }

        public List<PropPhoto> PropertyPhotos { get; set; }

        public List<PropFeature> Features { get; set; }

        public List<Addvertisiment> ActiveAdds { get; set; }

    }


    
}
