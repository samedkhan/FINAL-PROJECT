using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using FINAL.Models;
using Microsoft.AspNetCore.Http;

namespace FINAL.Areas.Admin.ViewModels
{
    public class APHomeIndexViewModel
    {
        public WebsiteSetting setting { get; set; }

        public APSettingEditModel settingEdit { get; set; }
    }

    public class APSettingEditModel
    {
        [MaxLength(100)]
        public string MainLogo { get; set; }

        public IFormFile Logo1 { get; set; }

        [MaxLength(100)]
        public string FooterLogo { get; set; }

        public IFormFile Logo2 { get; set; }

        [Required(ErrorMessage = "Facebook ünvanı daxil edin")]
        [MaxLength(100)]
        public string FacebookAddress { get; set; }

        [Required(ErrorMessage = "Twitter ünvanı daxil edin")]
        [MaxLength(100)]
        public string TwitterAdress { get; set; }


        [Required(ErrorMessage = "Linkedin ünvanı daxil edin")]
        [MaxLength(100)]
        public string LinkedinAddress { get; set; }


        [Required(ErrorMessage = "Ünvanı daxil edin")]
        [MaxLength(100)]
        public string LocalAddress { get; set; }


        [Required(ErrorMessage = "Telefon daxil edin")]
        [MaxLength(15)]
        public string PhoneNumber { get; set; }


        [Required(ErrorMessage = "Mobil nömrəni daxil edin")]
        [MaxLength(15)]
        public string MobileNumber { get; set; }


        [Required(ErrorMessage = "E-poçt ünvanı daxil edin")]
        [EmailAddress(ErrorMessage = "E-poçt ünvanı daxil edin")]
        public string Email { get; set; }

      
        public string About { get; set; }
    }
}
