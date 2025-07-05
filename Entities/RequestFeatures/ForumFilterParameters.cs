using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.RequestFeatures
{
    public class ForumFilterParameters : RequestFeatures
    {
        public int? ForumQuestionCategoryId { get; set; }
        public bool SortByAlphabetical { get; set; }
        public bool SortByAlphabeticalDescending { get; set; }
        public bool SortByDate { get; set; }
        public bool SortByDateAscending { get; set; }
    }
}

