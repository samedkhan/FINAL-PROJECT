using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FINAL.Models
{
    //Kiraye, Satilir, Kiraye gunluk
    public class AddType
    {
        [Key]
        public int AddTypeId { get; set; }

        [MaxLength(50)]
        public string Name { get; set; }


        public List<Addvertisiment> Adds { get; set; }
    }
}
