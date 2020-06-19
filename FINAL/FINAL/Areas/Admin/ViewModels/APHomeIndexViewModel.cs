using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using FINAL.Models;

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
        [Required(ErrorMessage = "Başlıq üçün Loqo fotosunu daxil edin")]
        public string MainLogo { get; set; }

        [Required(ErrorMessage = "E-poçt ünvanı daxil edin")]
        [MaxLength(100)]
        public string FooterLogo { get; set; }

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


        [Required(ErrorMessage = "Haqqında məlumat daxil edin")]
        public string About { get; set; }
    }
}
