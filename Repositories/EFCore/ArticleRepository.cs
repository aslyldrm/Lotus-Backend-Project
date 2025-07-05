using Entities.DataTransferObjects.Article;
using Entities.Models;
using Entities.RequestFeatures;
using Microsoft.EntityFrameworkCore;
using Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.EFCore
{
    public class ArticleRepository : RepositoryBase<Article>, IArticleRepository
    {
        public ArticleRepository(RepositoryContext context) : base(context)
        {
        }

        public void CreateOneArticle(Article article) =>
            Create(article);
       

        public void DeleteOneArticle(Article article) =>
            Delete(article);
        private void ApplyFilters(ref IQueryable<Article> articles, ArticleParameters articleParameters)
        {
            if (articleParameters.ArticleCategoryId.HasValue)
            {
                articles = articles.Where(a => a.ArticleCategoryId == articleParameters.ArticleCategoryId.Value);
            }

            if (articleParameters.SortByAlphabetical)
            {
                articles = articles.OrderBy(a => a.Title);
            }
            if (articleParameters.SortByAlphabeticalDescending)
            {
                articles = articles.OrderByDescending(a => a.Title);
            }
            if (articleParameters.SortByDate)
            {
                articles = articles.OrderByDescending(a => a.ReleaseDate);
            }
            if (articleParameters.SortByDateAscending)
            {
                articles = articles.OrderBy(a => a.ReleaseDate);
            }
        }
        public async Task<IEnumerable<Article>> GetFilteredArticlesAsync(ArticleParameters articleParameters, bool trackChanges)
        {
            var articlesQuery = FindAll(trackChanges)
                   .Include(x => x.ArticleCategory)
                   .AsQueryable();

            ApplyFilters(ref articlesQuery, articleParameters);

            // Removing the OrderBy(x => x.Id) here as sorting should be handled within ApplyFilters
            var articles = await articlesQuery.ToListAsync();

            return PagedList<Article>
                .ToPagedList(articles, articleParameters.PageNumber, articleParameters.PageSize);

        }
        public async Task<PagedList<Article>> GetAllArticlesAsync(ArticleParameters articleParameters, bool trackChanges)
        {
            var articles = await FindAll(trackChanges)
            .OrderBy(x => x.Id)
            .ToListAsync();

            return PagedList<Article>
                .ToPagedList(articles, articleParameters.PageNumber,
                articleParameters.PageSize);

        }
        public async Task<Article> GetOneArticleByIdAsync(int id, bool trackChanges) =>
            await FindByCondition(b => b.Id.Equals(id), trackChanges)
            .SingleOrDefaultAsync();




        public void UpdateOneArticle(Article article) =>
            Update(article);
       
    }
}
