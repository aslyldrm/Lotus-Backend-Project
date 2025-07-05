using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.RequestFeatures
{
    public class PodcastFilterParameters : RequestFeatures
    {
        public int? PodcastCategoryId { get; set; }
        public bool SortByAlphabetical { get; set; }
        public bool SortByAlphabeticalDescending { get; set; }
        public bool SortByDate { get; set; }
        public bool SortByDateAscending { get; set; }
  
    }
}
