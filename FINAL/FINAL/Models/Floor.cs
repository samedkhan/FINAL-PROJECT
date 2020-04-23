using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FINAL.Models
{
    public class Floor
    {
        public int FloorID { get; set; }

        public string FloorNumber { get; set; }

        public List<Property> Properties { get; set; }
    }
}
