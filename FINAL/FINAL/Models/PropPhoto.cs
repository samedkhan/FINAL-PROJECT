using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FINAL.Models
{
    public class PropPhoto
    {
        [Key]
        public int PropPhotoId { get; set; }

        [MaxLength(100)]
        public string PropPhotoName { get; set; }

        [ForeignKey("Property")]
        public int PropertyId { get; set; }

        public Property Property { get; set; }
    }
}
