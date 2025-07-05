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
    public class ForumRepository : RepositoryBase<Forum>, IForumRepository
    {
        public ForumRepository(RepositoryContext context) : base(context)
        {
        }

        public void CreateOneForum(Forum forum)
         => Create(forum);
        public void DeleteOneForum(Forum forum)
         => Delete(forum);

        public async Task<IEnumerable<Forum>> GetAllForumAsync(bool trackChanges)
         => await FindAll(trackChanges)
            .OrderBy(c => c.QuestionId)
            .ToListAsync();

        public async Task<Forum> GetOneForumAsync(int id, bool trackChanges)
        => await FindByCondition(c => c.QuestionId.Equals(id), trackChanges)
            .SingleOrDefaultAsync();
        public void UpdateOneForum(Forum forum)
         => Update(forum);


        public async Task<IEnumerable<Forum>> GetFilteredForumQuestionAsync(ForumFilterParameters forumParameters, bool trackChanges)
        {
            var forumQuestionsQuery = FindAll(trackChanges)
                    .Include(x => x.ForumQuestionCategory)
                    .AsQueryable();

            ApplyFilters(ref forumQuestionsQuery, forumParameters);

           // var forums = await forumQuestionsQuery.AsNoTracking().ToListAsync(); // AsNoTracking() ekleyin

            return PagedList<Forum>
                .ToPagedList(forumQuestionsQuery, forumParameters.PageNumber, forumParameters.PageSize);
        }

        private void ApplyFilters(ref IQueryable<Forum> forumQuestions, ForumFilterParameters forumParameters)
        {
            if (forumParameters.ForumQuestionCategoryId.HasValue)
            {
                forumQuestions = forumQuestions.Where(a => a.ForumQuestionCategoryId == forumParameters.ForumQuestionCategoryId.Value);
            }

            if (forumParameters.SortByAlphabetical)
            {
                forumQuestions = forumQuestions.OrderBy(a => a.Question);
            }
            if (forumParameters.SortByAlphabeticalDescending)
            {
                forumQuestions = forumQuestions.OrderByDescending(a => a.Question);
            }
            if (forumParameters.SortByDate)
            {
                forumQuestions = forumQuestions.OrderByDescending(a => a.CreationDate);
            }
            if (forumParameters.SortByDateAscending)
            {
                forumQuestions = forumQuestions.OrderBy(a => a.CreationDate);
            }
        }
    }
}
