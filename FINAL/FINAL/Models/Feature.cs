using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace FINAL.Models
{
    //asma tavan, isti dosheme
    public class Feature
    {
        [Key]
        public int FeatureID { get; set; }

        [MaxLength(50)]
        public string Name { get; set; }

       
        public List<PropFeature> PropFeatures { get; set; }
    }
}
