
using Entities.DataTransferObjects.Forum;
using Entities.DataTransferObjects.ForumQuestion;
using Entities.Models;
using Entities.Models.Categories;
using Entities.RequestFeatures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Contracts
{
    public interface IForumService
    {
        Task<IEnumerable<Forum>> GetAllForumAsync(bool trackChanges);
        Task<ForumDto> CreateOneForum(ForumDtoForInsertion forumDto);
        Task UpdateOneForum(int id, ForumDtoForUpdate forumDto, bool trackChanges);
        Task DeleteOneForumQuestion(int questionId, bool trackChanges);
        Task<ForumDto> GetOneForumByIdAsync(int id, bool trackChanges);
        Task<IEnumerable<ForumFilterDto>> GetFilteredForumAsync(ForumFilterParameters forumParameters, bool trackChanges);
        Task<IEnumerable<ForumWithAnswersDto>> SearchForumQuestionsByQuestionTitleAsync(string questionTitle, bool trackChanges);
        Task<IEnumerable<ForumDto>> GetUserForumQuestionsAsync(string userId, bool trackChanges);
    }
}
