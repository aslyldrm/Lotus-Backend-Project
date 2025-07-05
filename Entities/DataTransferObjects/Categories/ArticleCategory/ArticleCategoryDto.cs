using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DataTransferObjects.Category.ArticleCategory
{
    public record ArticleCategoryDto
    {
        public int ArticleCategoryId { get; init; }
        public string? ArticleCategoryName { get; init; }
    }
}
