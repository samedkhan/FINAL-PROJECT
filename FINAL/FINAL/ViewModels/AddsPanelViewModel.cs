using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FINAL.Models;

namespace FINAL.ViewModels
{
    public enum ViewType
    {
        small = 0,
        normal = 1,
        big = 2,
    }
    public class AddsPanelViewModel
    {
        public List<Addvertisiment> AddList { get; set; }

        public ViewType type { get; set; }
    }
}
