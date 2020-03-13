using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace FINAL.Models
{
    public class WebsiteSetting
    {
        [Key]
        public int Id { get; set; }

        [MaxLength(100)]
        [Required]
        public string MainLogo { get; set; }

        public string FooterLogo { get; set; }

        [Required]
        [MaxLength(100)]
        public string FacebookAddress { get; set; }

        [Required]
        [MaxLength(100)]
        public string TwitterAdress { get; set; }

        [Required]
        [MaxLength(100)]
        public string LinkedinAddress { get; set; }

        [Required]
        [MaxLength(100)]
        public string LocalAddress { get; set; }

        [Required]
        [MaxLength(15)]
        public string PhoneNumber { get; set; }

        [Required]
        [MaxLength(15)]
        public string MobileNumber { get; set; }

        [Required]
        [MaxLength(50)]
        [EmailAddress]
        public string Email { get; set; }
    }
}
