using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FINAL.Models;

namespace FINAL.ViewModels
{
    public class CabinetIndexViewModel
    {
        public BreadcumbViewModel Breadcumb { get; set; }

        public List<Addvertisiment> AllAdds { get; set; }

        public List<Addvertisiment> ActiveAdds { get; set; }

        public List<Addvertisiment> DeactiveAdds { get; set; }

        public List<Addvertisiment> WaitingAdds { get; set; }

        public List<Addvertisiment> RentAdds { get; set; }

        public List<Addvertisiment> SaleAdds { get; set; }

    }

    

}
