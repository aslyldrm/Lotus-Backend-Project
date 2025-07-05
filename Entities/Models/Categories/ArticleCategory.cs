using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models.Categories
{
    public class ArticleCategory
    {
        [Key]
        public int ArticleCategoryId { get; set; }
        public String? ArticleCategoryName { get; set; }

        //Ref Definition: Collection navigation property
        //public ICollection<Article> Articles { get; set; }

    }
}
