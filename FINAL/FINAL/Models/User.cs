using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FINAL.Models
{
    public enum UserType
    {
        EvSahibi = 0,
        Vasiteci = 1,
        Agentlik = 2
    }
    public class User
    {
        [Key]
        public int UserId { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        [Required]
        [MaxLength(50)]
        public string Surname { get; set; }

        [Required]
        [MaxLength(150)]
        public string Password { get; set; }

        public string Token { get; set; }

        [Required]
        public UserType UserType { get; set; }


        public string Photo { get; set; }

        [Required]
        [MaxLength(100)]
        public string Email { get; set; }

        public List<ContactNumber> ContactNumbers { get; set; }

        [MaxLength(100)]
        public string Address { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime SignDate { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime LastLoginDate { get; set; }

        public List<PropAdd> PropAdds { get; set; }
    }
}
