using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace FINAL.Models
{
    public class Adress
    {
        [Key]
        public int AdressId { get; set; }
        
        [Required]
        public int CityId { get; set; }
        public City City { get; set; }

        public List<PropAdd> PropAdds { get; set; }
    }
}
