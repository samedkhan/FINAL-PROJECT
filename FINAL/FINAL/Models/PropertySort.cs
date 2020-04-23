using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace FINAL.Models
{
    //Property sort (Villa, Newbuilding or etc)
    public class PropertySort
    {
        [Key]
        public int PropertySortId { get; set; }

        [Required]
        [MaxLength(15)]
        public string PropertySortName { get; set; }

        [MaxLength(100)]
        public string DataFilter { get; set; }

        public List<Property> Properties { get; set; }
    }
}
