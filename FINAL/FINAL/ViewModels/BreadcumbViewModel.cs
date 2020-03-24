using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FINAL.ViewModels
{
    public class BreadcumbViewModel
    {
        public string Title { get; set; }

        //public Dictionary<string, string> Path { get; set; }

        public List<BreadcumbItemViewModel> Path { get; set; }

    }

    public class BreadcumbItemViewModel
    {
        public string Name { get; set; }

        public string Controller { get; set; }

        public string Action { get; set; }
    }
}
