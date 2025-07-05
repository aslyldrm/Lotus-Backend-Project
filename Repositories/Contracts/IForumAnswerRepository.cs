using Entities.Models;
using Entities.Models.Categories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Contracts
{
    public interface IForumAnswerRepository : IRepositoryBase<ForumQuestionAnswers>
    {


        // void CreateOneForumAnswer(ForumQuestionAnswers forum);
        // void UpdateOneForumAnswer(ForumQuestionAnswers forum);
        // void DeleteOneForumAnswer(ForumQuestionAnswers forum);

        Task<IEnumerable<ForumQuestionAnswers>> GetAnswersByQuestionIdAsync(int questionId, bool trackChanges);
        Task<ForumQuestionAnswers> GetAnswerByIdAsync(int questionId, int answerId, bool trackChanges);
    }
}
