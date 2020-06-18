using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FINAL.Areas.Admin.Models
{
    public class APuser
    {
        [Key]
        public int APUserId { get; set; }

        [Required]
        [EmailAddress]
        [MaxLength(100)]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        public string Nickname { get; set; }

        public string Token { get; set; }

        [Required]
        public bool isAdmin { get; set; }

        
        public bool isSuperAdmin { get; set; }
    }
}
