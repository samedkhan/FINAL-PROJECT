using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FINAL.Models;

namespace FINAL.ViewModels
{
    public class OwnerPanelViewModel
    {
        public User Owner { get; set; }

        public int OwnerActiveAdds { get; set; }
    }
}
