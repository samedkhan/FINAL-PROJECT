using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FINAL.Models
{
    public class City
    {
        [Key]
        public int CityId { get; set; }

        [Required]
        [MaxLength(50)]
        public string CityName { get; set; }

        [Required]
        [Column(TypeName = "float")]
        public float Longitude { get; set; }

        [Required]
        [Column(TypeName = "float")]
        public float Latitude { get; set; }

        public List<District> Districts { get; set; }

        public List<Property> Properties { get; set; }

    }
}
