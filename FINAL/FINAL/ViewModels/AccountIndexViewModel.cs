using FINAL.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace FINAL.ViewModels
{
    public class AccountIndexViewModel
    {
        public BreadcumbViewModel Breadcumb { get; set; }
        public OwnerPanelViewModel Owner { get; set; }
        public AddsPanelViewModel AddsPanel { get; set; }
        public AccountRegisterModel Register { get; set; }
        public AccountLoginModel Login { get; set; }
        public AccountSettingModel Setting { get; set; }
        public AccountCabinetModel Cabinet { get; set; }
    }

    public class AccountRegisterModel
    {
        [Required(ErrorMessage = "Qeyd edin")]
        public int UserTypeId { get; set; }

        [Required(ErrorMessage = "Adınızı daxil etməminiz !!!")]
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

        [Required]
        public string PhoneNumber { get; set; }
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

    public class AccountSettingModel
    {
        [Required(ErrorMessage = "Adınızı daxil etməminiz !!!")]
        [MaxLength(50)]
        [MinLength(3)]
        public string Name { get; set; }


        [MaxLength(50)]
        [MinLength(3)]
        public string Surname { get; set; }


        [Column(TypeName = "ntext")]
        public string Adress { get; set; }

        [Required]
        public string PhoneNumber { get; set; }

        public IFormFile Photo { get; set; }

        [MaxLength(150)]
        public string LogoImage { get; set; }
    }

    public class AccountCabinetModel
    {

        public List<Addvertisiment> AllAdds { get; set; }

        public List<Addvertisiment> ActiveAdds { get; set; }

        public List<Addvertisiment> DeactiveAdds { get; set; }

        public List<Addvertisiment> WaitingAdds { get; set; }

        public List<Addvertisiment> RentAdds { get; set; }

        public List<Addvertisiment> SaleAdds { get; set; }

    }

}
