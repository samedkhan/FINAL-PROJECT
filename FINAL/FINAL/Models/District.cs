using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FINAL.Models
{
    public class District
    {
        [Key]
        public int DistrictId { get; set; }

        [Required]
        [MaxLength(50)]
        public string DistrictName { get; set; }

        [ForeignKey("City")]
        public int CityID { get; set; }

        public City City { get; set; }

        public List<Property> Properties { get; set; }

    }
}
