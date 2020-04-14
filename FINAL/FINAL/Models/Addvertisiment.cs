using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FINAL.Models
{

  
    public enum AddStatus
    {
        Waiting = 0,
        Active = 1,
        Deactive = 2,
        Hidden = 3
    }

    public class Addvertisiment
    {
        [Key]
        public int AddvertisimentID { get; set; }

        [ForeignKey("Property")]
        public int PropertyID { get; set; }

        [Required]
        public Property Property { get; set; }


        [ForeignKey("User")]
        public int UserId { get; set; }
        public User User { get; set; }


        [ForeignKey("AddType")]
        public int AddTypeID { get; set; }

        [Required]
        public AddType AddType { get; set; }


        [Required]
        [Column(TypeName = "money")]
        public decimal PropPrice { get; set; }

        [Required]
        [Column(TypeName = "datetime")]
        public DateTime CreatedAt { get; set; }


        [Required]
        public AddStatus AddStatus { get; set; }

    }
}
