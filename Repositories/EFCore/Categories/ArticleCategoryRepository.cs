using Entities.Models.Categories;
using Microsoft.EntityFrameworkCore;
using Repositories.Contracts.Categories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.EFCore.Categories
{


    public class ArticleCategoryRepository : RepositoryBase<ArticleCategory>, IArticleCategoryRepository
    {
        public ArticleCategoryRepository(RepositoryContext context) : base(context)
        {
        }

        public void CreateOneArticleCategory(ArticleCategory category) =>
            Create(category);


        public void DeleteOneArticleCategory(ArticleCategory category) =>
            Delete(category);


        public async Task<IEnumerable<ArticleCategory>> GetAllArticleCategoriesAsync(bool trackChanges)
          => await FindAll(trackChanges)
            .OrderBy(c => c.ArticleCategoryName)
            .ToListAsync();

        public async Task<ArticleCategory> GetOneArticleCategoryAsync(int id, bool trackChanges)
           => await FindByCondition(c => c.ArticleCategoryId.Equals(id), trackChanges)
            .SingleOrDefaultAsync();
        public void UpdateOneArticleCategory(ArticleCategory category)
         => Update(category);
    }
}
