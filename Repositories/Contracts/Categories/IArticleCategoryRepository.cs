using Entities.Models.Categories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Contracts.Categories
{
    public interface IArticleCategoryRepository : IRepositoryBase<ArticleCategory>
    {
        Task<IEnumerable<ArticleCategory>> GetAllArticleCategoriesAsync(bool trackChanges);

        void CreateOneArticleCategory(ArticleCategory category);
        void UpdateOneArticleCategory(ArticleCategory category);
        void DeleteOneArticleCategory(ArticleCategory category);

        Task<ArticleCategory> GetOneArticleCategoryAsync(int id, bool trackChanges);
    }
}
