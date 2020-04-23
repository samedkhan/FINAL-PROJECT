using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FINAL.Models
{
    public class PropDoc
    {
        [Key]
        public int PropDocID { get; set; }

        [Required]
        [MaxLength(50)]
        public string PropDocName { get; set; }

        public List<Property> Properties { get; set; }
    }
}
