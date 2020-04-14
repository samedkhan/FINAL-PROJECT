using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace FINAL.Models
{
    public enum PropDoc
    {
        Kupca = 0,
        Muqavile = 1,
        BelediyyeSenedi = 2,
        Serencam = 3,
        Kupcasiz = 4,
        Etibarname = 5
    }

    public class Property
    {
        public int PropertyId { get; set; }
        
        [MaxLength(50)]
        public string Name { get; set; }

        [ForeignKey("City")]
        public int CityId { get; set; }

        public City City { get; set; }


        [ForeignKey("District")]
        public int? DistrictId { get; set; }

        public District District { get; set; }


        [ForeignKey("PropertySort")]
        public int PropertySortId { get; set; }
        public PropertySort PropertySort { get; set; }

        [Required]
        public PropDoc PropDoc { get; set; }

        public int? PropFloorSum { get; set; }

        public int? PropFloorNumber { get; set; }

        public int? FlatSum { get; set; }

        [Required]
        [Column(TypeName = "money")]
        public decimal Volume { get; set; }

        [Column(TypeName = "ntext")]
        [Required(ErrorMessage = "Əmlak haqqında ətraflı yazın")]
        [MinLength(100)]
        public string FullAbout { get; set; }

        [Required]
        [MaxLength(100)]
        public string MainPhoto { get; set; }

        [Column(TypeName = "ntext")]
        [Required(ErrorMessage = "Ünvanı düzgün qeyd edin")]
        public string FullAddress { get; set; }

        [Required]
        [Column(TypeName = "float")]
        public float Longitude { get; set; }

        [Required]
        [Column(TypeName = "float")]
        public float Latitude { get; set; }

        public List<PropPhoto> Photos { get; set; }

        public List<PropFeature> PropFeatures { get; set; }

    }
}
