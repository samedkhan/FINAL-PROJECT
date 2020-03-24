using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace FINAL.Models
{
    // asma-tavan, isti-dosheme ve s xarakterler
    public class PropertyCharacter 
    {
        [Key]
        public int PCId { get; set; }

        [Required]
        [MaxLength(15)]
        public string PCName { get; set; }


    }
}
