using Entities.Models.Categories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Contracts.Categories
{
    public interface IForumQuestionCategory : IRepositoryBase<ForumQuestionCategory>
    {
        Task<IEnumerable<ForumQuestionCategory>> GetAllForumQuestionCategoriesAsync(bool trackChanges);

        void CreateOneForumQuestionCategory(ForumQuestionCategory category);
        void UpdateOneForumQuestionCategory(ForumQuestionCategory category);
        void DeleteOneForumQuestionCategory(ForumQuestionCategory category);

        Task<ForumQuestionCategory> GetOneForumQuestionCategoryAsync(int id, bool trackChanges);
    }
}
