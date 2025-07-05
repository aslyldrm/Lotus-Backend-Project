using Entities.Models.Categories;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models
{
    public class Article
    {

        public int Id { get; set; }
        public  string Title { get; set; }
        public string ContentText { get; set; }
        //Category : 
        public DateTime ReleaseDate { get; set; } = DateTime.Now;
        public string Writers { get; set; }
        public string? Image { get; set; }

        public int ArticleCategoryId { get; set; }
        public ArticleCategory? ArticleCategory { get; set; }

    }
}
