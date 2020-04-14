using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FINAL.Models
{
 
    public class User
    {
        [Key]
        public int UserId { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        [MaxLength(50)]
        public string Surname { get; set; }

        [Required]
        [MaxLength(150)]
        public string Password { get; set; }

        [Required]
        [MaxLength(100)]
        public string Email { get; set; }
        

        [MaxLength(15)]
        public string PhoneNumber { get; set; }

        public string Token { get; set; }
        
        [MaxLength(100)]
        public string Logo { get; set; }
      

        [Column(TypeName = "ntext")]
        public string AboutCompany { get; set; }

        [MaxLength(100)]
        [Column(TypeName = "ntext")]
        public string Adress { get; set; }

        [Column(TypeName = "date")]
        public DateTime CreatedAt { get; set; }

        [Required]
        [ForeignKey("UserType")]
        public int UserTypeID { get; set; }

        public UserType UserType { get; set; }

        public List<Addvertisiment> Adds { get; set; }

        
    }
}
