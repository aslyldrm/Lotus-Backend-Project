using Entities.DataTransferObjects.Category.ArticleCategory;

using Entities.Models.Categories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Contracts.Categories
{
    public interface IArticleCategoryService
    {
        Task<IEnumerable<ArticleCategory>> GetAllCategoriesAsync(bool trackChanges);
        Task<ArticleCategoryDto> CreateOneArticleCategory(ArticleCategoryDtoForInsertion articleCategoryDto);
        Task UpdateOneArticleCategory(ArticleCategoryDtoForUpdate articleCategory, bool trackChanges);
        Task DeleteOneArticleCategory(int id, bool trackChanges);
    }
}
