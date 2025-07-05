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
    public class ForumQuestionCategoryRepository : RepositoryBase<ForumQuestionCategory>, IForumQuestionCategory
    {
        public ForumQuestionCategoryRepository(RepositoryContext context) : base(context)
        {
        }

        public void CreateOneForumQuestionCategory(ForumQuestionCategory category)
       => Create(category);

        public void DeleteOneForumQuestionCategory(ForumQuestionCategory category)
        =>
            Delete(category);
        public async Task<IEnumerable<ForumQuestionCategory>> GetAllForumQuestionCategoriesAsync(bool trackChanges)
          => await FindAll(trackChanges)
            .OrderBy(c => c.ForumQuestionCategoryName)
            .ToListAsync();

        public async Task<ForumQuestionCategory> GetOneForumQuestionCategoryAsync(int id, bool trackChanges)
         => await FindByCondition(c => c.ForumQuestionCategoryId.Equals(id), trackChanges)
            .SingleOrDefaultAsync();

        public void UpdateOneForumQuestionCategory(ForumQuestionCategory category)
         => Update(category);
    }
}
