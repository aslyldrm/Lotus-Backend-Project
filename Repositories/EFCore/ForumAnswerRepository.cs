using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.EFCore
{
    public class ForumAnswerRepository : RepositoryBase<ForumQuestionAnswers>, IForumAnswerRepository
    {
        public ForumAnswerRepository(RepositoryContext context) : base(context)
        {
        }

        public async Task<ForumQuestionAnswers> GetAnswerByIdAsync(int questionId, int answerId, bool trackChanges)
        {
            return await FindByCondition(f => f.QuestionId.Equals(questionId) && f.AnswerId.Equals(answerId), trackChanges)
                       .SingleOrDefaultAsync();
        }

        public async Task<IEnumerable<ForumQuestionAnswers>> GetAnswersByQuestionIdAsync(int questionId, bool trackChanges)
        {
            return await FindByCondition(f => f.QuestionId.Equals(questionId), trackChanges)
                        .ToListAsync();
        }
    }
}
