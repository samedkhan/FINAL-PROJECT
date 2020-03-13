using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace FINAL.Models
{
    public class PropertyCharacter
    {
        [Key]
        public int PCId { get; set; }

        [Required]
        [MaxLength(15)]
        public string PCName { get; set; }

        public int PropAddId { get; set; }

        public PropAdd PropAdd { get; set; }

    }
}
