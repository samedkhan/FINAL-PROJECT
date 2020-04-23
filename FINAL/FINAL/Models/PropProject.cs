using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace FINAL.Models
{
    public class PropProject
    {
        [Key]
        public int PropProjectID { get; set; }

        [Required]
        [MaxLength(50)]
        public string PropProjectName { get; set; }

        [ForeignKey("PropertySort")]
        public int PropertySortId { get; set; }

        public PropertySort PropertySort { get; set; }

        public List<Property> Properties { get; set; }
    }
}
