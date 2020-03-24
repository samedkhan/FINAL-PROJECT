using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace FINAL.Models
{
    public class ContactNumber
    {
        [Key]
        public int ContactNumberId { get; set; }

        [Required]
        [MaxLength(50)]
        public string ContactName { get; set; } //Whatsapp, Telegram, Fax and etc

        [Required]
        [MaxLength(10)]
        [MinLength(10)]
        public string Number { get; set; }
    }
}
