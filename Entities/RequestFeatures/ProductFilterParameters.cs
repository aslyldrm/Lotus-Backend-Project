using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.RequestFeatures
{
    public class ProductFilterParameters : ProductParameters
    {
        public uint MinPrice { get; set; } = 0;
        public uint MaxPrice { get; set; } = 10000;
        public bool ValidPriceRange => MaxPrice > MinPrice;
        public int? CategoryId { get; set; }
        public string City { get; set; }
        public bool SortByDate { get; set; }
        public bool SortByDateAscending { get; set; }
        public bool SortByPrice { get; set; }
        public bool SortByPriceAscending { get; set; }
    }
}
