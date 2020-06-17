using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FINAL.Areas.Admin.Models
{
    public enum UserStatus
    {
        Administrator = 0,
        Moderator = 1,
    }
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

        public UserStatus Status  { get; set; }
    }
}
