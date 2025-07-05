using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DataTransferObjects.Category.ArticleCategory
{
    public record ArticleCategoryDtoForUpdate : ArticleCategoryDtoForManipulation
    {
        public int ArticleCategoryId { get; init; }
    }
}
