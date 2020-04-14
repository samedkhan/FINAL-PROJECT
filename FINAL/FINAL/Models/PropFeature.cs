using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace FINAL.Models
{
    public class PropFeature
    {
        [Key]
        public int PropFeatureID { get; set; }

        [ForeignKey("Property")]
        public int PropertyID { get; set; }
        
        public Property Property { get; set; }

        [ForeignKey("Feature")]
        public int FeatureID { get; set; }

        public Feature Feature { get; set; }
    }
}
