using Entities.DataTransferObjects.Article;
using Entities.Models;
using Entities.RequestFeatures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Contracts
{
    public interface IArticleRepository : IRepositoryBase<Article>
    {
        Task<PagedList<Article>> GetAllArticlesAsync(ArticleParameters articleParameters, bool trackChanges);
        Task<Article> GetOneArticleByIdAsync(int id, bool trackChanges);
        void CreateOneArticle(Article article);
        void UpdateOneArticle(Article article);
        void DeleteOneArticle(Article article);
        Task<IEnumerable<Article>> GetFilteredArticlesAsync(ArticleParameters filterParams, bool trackChanges);

    }
}
