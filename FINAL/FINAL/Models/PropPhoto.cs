using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace FINAL.Models
{
    public class PropPhoto
    {
        public int PropPhotoId { get; set; }

        public string PropPhotoName { get; set; }

        public int PropAddId { get; set; }

        public PropAdd PropAdd { get; set; }
    }
}
