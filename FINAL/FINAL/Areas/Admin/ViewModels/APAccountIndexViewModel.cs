using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using FINAL.Areas.Admin.Models;

namespace FINAL.Areas.Admin.ViewModels
{
    public class APAccountIndexViewModel
    {
        public APAccountLoginModel Login { get; set; }

        public APAccountCreateModel Create { get; set; }

        public List<APuser> APUsers { get; set; }
    }
   
    public class APAccountLoginModel
    {
        [Required(ErrorMessage = "E-poçt daxil edin")]
        [EmailAddress(ErrorMessage = "E-poçt ünvanı daxil edin")]
        public string Email { get; set; }


        [Required(ErrorMessage = "Şifrə daxil edin")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        
    }

    public class APAccountCreateModel
    {
        [Required(ErrorMessage = "Növü seçin")]
        public int UserStatusId { get; set; }

        [Required(ErrorMessage = "Ad daxil edin")]
        [MaxLength(50)]
        public string Name { get; set; }

        [Required(ErrorMessage = "E-poçt daxil edin")]
        [EmailAddress(ErrorMessage = "E-poçt ünvanı daxil edin")]
        public string Email { get; set; }


        [Required(ErrorMessage = "Şifrə daxil edin")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
