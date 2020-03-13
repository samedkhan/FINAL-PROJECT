using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace FINAL.Models
{
    public class Region
    {
        [Key]
        public int RegionId { get; set; }

        [Required]
        [MaxLength(50)]
        public string RegionName { get; set; }

        [Required]
        public int DistrictId { get; set; }

        public District District { get; set; }
    }
}
