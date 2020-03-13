using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace FINAL.Models
{
    public class District
    {
        [Key]
        public int DistrictId { get; set; }

        [Required]
        [MaxLength(50)]
        public string DistrictName { get; set; }

        [Required]
        public int CityId { get; set; }

        public City City { get; set; }

        public List<Region> Regions { get; set; }
    }
}
