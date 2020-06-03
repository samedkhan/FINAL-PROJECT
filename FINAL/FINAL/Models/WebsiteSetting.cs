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

        [MaxLength(100)]
        public string FooterLogo { get; set; }

        [MaxLength(100)]
        public string FacebookAddress { get; set; }

       
        [MaxLength(100)]
        public string TwitterAdress { get; set; }


        [MaxLength(100)]
        public string LinkedinAddress { get; set; }

        [MaxLength(100)]
        public string LocalAddress { get; set; }

        
        [MaxLength(15)]
        public string PhoneNumber { get; set; }

       
        [MaxLength(15)]
        public string MobileNumber { get; set; }


        [MaxLength(50)]
        [EmailAddress]
        public string Email { get; set; }

        public string About { get; set; }

    }

}
