using Entities.DataTransferObjects.Article;
using Entities.DataTransferObjects.User;
using Entities.Models;
using Entities.RequestFeatures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Contracts
{
    public interface IArticleService
    {
        Task<(IEnumerable<Article> articles, MetaData metaData)> GetAllArticlesAsync(ArticleParameters articleParameters, bool trackChanges);
        Task<ArticleDto> GetOneArticleByIdAsync(int id, bool trackChanges);
        Task<ArticleDto> CreateOneArticleAsync(ArticleDtoForInsertion article);
        Task UpdateOneArticleAsync(int id, ArticleDtoForUpdate articleDto, bool trackChanges);
        Task DeleteOneArticleAsync(int id, bool trackChanges);
        Task<IEnumerable<ArticleDto>> GetFilteredArticlesAsync(ArticleParameters articleParameters, bool trackChanges);
        Task<IEnumerable<Article>> SearchArticlesByTitleAsync(string title, bool trackChanges);
    }
}
