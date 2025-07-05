using Entities.Models;
using Entities.Models.Categories;
using Entities.RequestFeatures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Contracts
{
    public interface IForumRepository : IRepositoryBase<Forum>
    {
        Task<IEnumerable<Forum>> GetAllForumAsync(bool trackChanges);

        void CreateOneForum(Forum forum);
        void UpdateOneForum(Forum forum);
        void DeleteOneForum(Forum forum);
        Task<IEnumerable<Forum>> GetFilteredForumQuestionAsync(ForumFilterParameters forumParameters, bool trackChanges);
        Task<Forum> GetOneForumAsync(int id, bool trackChanges);
    }
}
