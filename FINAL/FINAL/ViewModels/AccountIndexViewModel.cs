using FINAL.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FINAL.ViewModels
{
    public class AccountIndexViewModel
    {
        public BreadcumbViewModel Breadcumb { get; set; }
        public AccountRegisterModel Register { get; set; }
        public AccountLoginModel Login { get; set; }
    }

    public class AccountRegisterModel
    {
        [Required(ErrorMessage = "Qeyd edin")]
        public UserType Type { get; set; }

        [Required(ErrorMessage = "Adınızı daxil edin")]
        [MaxLength(50)]
        [MinLength(3)]
        public string Name { get; set; }

    
        [MaxLength(50)]
        [MinLength(3)]
        public string Surname { get; set; }


        [Required(ErrorMessage = "Şifrə daxil edin")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required(ErrorMessage = "Şifrənizi təkrar daxil edin")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Şifrənin təkrarı sifrə ilə eyni olmalıdır!")]
        public string RePassword { get; set; }

        [Required(ErrorMessage = "E-poçt ünvanı daxil edin")]
        [EmailAddress(ErrorMessage = "E-poçt ünvanını düzgün daxil edin!")]
        public string Email { get; set; }
    }

    public class AccountLoginModel
    {
        [Required(ErrorMessage = "E-poçt daxil edin")]
        [EmailAddress(ErrorMessage = "E-poçt ünvanı daxil edin")]
        public string Email { get; set; }


        [Required(ErrorMessage = "Şifrə daxil edin")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
