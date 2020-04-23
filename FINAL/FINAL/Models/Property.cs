using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace FINAL.Models
{

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

        [ForeignKey("PropDoc")]
        public int? PropDocId { get; set; }

        public PropDoc PropDoc { get; set; }

        [ForeignKey("Floor")]
        public int? FloorId { get; set; }

        public Floor Floor { get; set; }

        public int? FloorSum { get; set; }

        [ForeignKey("Flat")]
        public int? FlatId { get; set; }

        public Flat Flat { get; set; }

        [ForeignKey("PropProject")]
        public int? PropProjectId { get; set; }

        public PropProject Project { get; set; }

        [Required]
        [Column(TypeName = "money")]
        public decimal BuildingVolume { get; set; }

        [Column(TypeName = "money")]
        public decimal LandVolume { get; set; }

        [Column(TypeName = "ntext")]
        [Required(ErrorMessage = "Əmlak haqqında ətraflı yazın")]
        [MinLength(100)]
        [MaxLength(500)]
        public string FullAbout { get; set; }

        [Required]
        [MaxLength(100)]
        public string MainPhoto { get; set; }

        [Column(TypeName = "ntext")]
        [Required(ErrorMessage = "Ünvanı düzgün qeyd edin")]
        public string FullAddress { get; set; }

        
        [Column(TypeName = "float")]
        public float Longitude { get; set; }

        
        [Column(TypeName = "float")]
        public float Latitude { get; set; }

        public List<PropPhoto> Photos { get; set; }

        public List<PropFeature> PropFeatures { get; set; }

    }
}
