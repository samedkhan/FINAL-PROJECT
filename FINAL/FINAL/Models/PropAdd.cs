using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FINAL.Models
{
    public enum PropDoc
    {
        Kupca = 0,
        Muqavile = 1,
        BelediyyeSenedi = 2,
        Serencam = 3,
        Kupcasiz = 4,
        Etibarname = 5
    }
    public enum AddType
    {
        Satilir = 0,
        KirayeAyliq = 1,
        KirayeGunluk = 2
    }

    public enum SaleType
    {
        Kredit = 0,
        FaizsizKredit = 1,
        Ipoteka = 2,
        HazirIpoteka = 3,
        Barter = 4
    }

    public class PropAdd
    {
        [Key]
        public int PropAddId { get; set; }
        
        [Required]
        public bool IsActive { get; set; }

        [MaxLength(100)]
        public string PropertyName { get; set; }

        [Required]
        [Column(TypeName = "datetime")]
        public DateTime CreatedAt { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }
        
        public int PropertySortId { get; set; }
        public PropertySort PropertySort { get; set; }

        public int AddressId { get; set; }
        public Adress Adress { get; set; }

       
        [Column(TypeName = "ntext")]
        [Required(ErrorMessage = "Ünvanı düzgün qeyd edin")]
        public string FullAddress { get; set; }

        [Required]
        public AddType AddType { get; set; }

        [Required]
        public PropDoc PropDoc { get; set; }

        [Required]
        public SaleType SaleType { get; set; }

        [Required]
        public int PropFloorSum { get; set; }

        public int PropFloorNumber { get; set; }

        [Required]
        public int PropFlatSum { get; set; }

        [Required]
        [Column(TypeName = "money")]
        public decimal PropVolume { get; set; }

        [Required]
        [Column(TypeName = "money")]
        public decimal PropPrice { get; set; }

        public List<PropPhoto> PropPhotos { get; set; }

        public List<PropertyCharacter> PropertyCharacters { get; set; }

        [Column(TypeName = "ntext")]
        [Required(ErrorMessage = "Əmlak haqqında ətraflı yazın")]
        [MinLength(100)]
        public string FullAbout { get; set; }

        
        public bool AdminAgree { get; set; }


    }
}
