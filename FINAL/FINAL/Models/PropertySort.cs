using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace FINAL.Models
{
    public class PropertySort
    {
        [Key]
        public int PropertySortId { get; set; }

        [Required]
        [MaxLength(15)]
        public string PropertySortName { get; set; }

        public List<PropAdd> PropAdds { get; set; }
    }
}
