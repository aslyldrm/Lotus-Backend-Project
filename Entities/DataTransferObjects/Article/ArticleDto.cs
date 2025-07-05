using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DataTransferObjects.Article
{
    public record ArticleDto
    {
        public int Id { get; init; }
        public  string Title { get; init; }
        public  string ContentText { get; init; }

        public DateTime ReleaseDate { get; init; }
        public string Writers { get; init; }
        public string? Image { get; init; }
        public int ArticleCategoryId { get; init; }
       
    }
}
