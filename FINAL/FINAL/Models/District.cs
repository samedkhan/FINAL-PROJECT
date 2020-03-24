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

       
        public List<PropAdd> PropAdds { get; set; }

    }
}
