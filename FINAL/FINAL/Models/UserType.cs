using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FINAL.Models
{
    public class UserType
    {
        //Agentlik, Ev sahibi, Makler
        [Key]
        public int UserTypeId { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        public List<User> Users { get; set; }
    }
}
