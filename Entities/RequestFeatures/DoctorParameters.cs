using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.RequestFeatures
{
    public class DoctorParameters : RequestFeatures
    {


        public int? DoctorCategoryId { get; set; }
        public bool SortByAlphabetical { get; set; }
        public bool SortByAlphabeticalDescending { get; set; }

    }
}
