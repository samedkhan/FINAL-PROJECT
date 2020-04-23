using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FINAL.Models
{
    public class Flat
    {
        public int FlatID { get; set; }

        public string FlatNumber { get; set; }

        public List<Property> Properties { get; set; }
    }
}
