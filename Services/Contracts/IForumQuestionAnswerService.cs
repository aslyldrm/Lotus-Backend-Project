using Entities.DataTransferObjects.Forum;
using Entities.DataTransferObjects.ForumAnswers;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Contracts
{
    public interface IForumQuestionAnswerService
    {



        Task<IEnumerable<ForumAnswerDto>> GetAnswersByQuestionIdAsync(int questionId, bool trackChanges);
        Task<ForumAnswerDto> CreateOneForumQuestionAnswer(ForumAnswerDtoForInsertion forumAnswerDto);
        Task UpdateOneForumQuestionAnswer(int questionId, int answerId, ForumAnswerDtoForUpdate forumAnswerDto, bool trackChanges);
        Task DeleteOneForumQuestionAnswer(int questionId, int answerId, bool trackChanges);


        Task<ForumAnswerDto> GetOneForumQuestionAnswerByIdAsync(int questionId, int answerId, bool trackChanges);
        //Task<IEnumerable<ForumQuestionAnswers>> GetOneForumQuestionAnswersAsync(bool trackChanges);
        //Task<ForumAnswerDto> CreateOneForumQuestionAnswer(ForumAnswerDtoForInsertion forumAnswerDto);
        //Task UpdateOneForumQuestionAnswer(int id, ForumAnswerDtoForUpdate forumAnswerDto, bool trackChanges);
        //Task DeleteOneForumQuestionAnswer(int id, bool trackChanges);
        //Task<ForumAnswerDto> GetOneForumQuestionAnswerByIdAsync(int id, bool trackChanges);
    }
}
