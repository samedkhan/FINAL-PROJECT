using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace FINAL.Models
{
    public class Message
    {
        [Key]
        public int MessageId { get; set; }

        [MaxLength(100)]
        [Required]
        public string Namesurname { get; set; }

        [Required]
        [EmailAddress]
        [MaxLength(50)]
        public string Email { get; set; }

        [Required]
        [MaxLength(500)]
        public string Text { get; set; }

        
        public bool HasReaded { get; set; }


        [Required]
        [Column(TypeName = "datetime")]
        public DateTime CreatedAt { get; set; }

    }
}
