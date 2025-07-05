using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DataTransferObjects.Category.ArticleCategory
{
    public abstract record ArticleCategoryDtoForManipulation
    {
        [Required(ErrorMessage = "Category Name is a required field")]
        public string ArticleCategoryName { get; init; }
    }
}
