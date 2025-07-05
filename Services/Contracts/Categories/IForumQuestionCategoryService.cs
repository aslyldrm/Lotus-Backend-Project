
using Entities.DataTransferObjects.Category.ForumQuestionCategory;
using Entities.Models.Categories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Contracts.Categories
{
    public interface IForumQuestionCategoryService
    {
        Task<IEnumerable<ForumQuestionCategory>> GetAllCategoriesAsync(bool trackChanges);
        Task<ForumQuestionCategoryDto> CreateOneForumQuestionCategory(ForumQuestionCategoryDtoForInsertion forumQuestionCategoryDto);
        Task UpdateOneForumQuestionCategory(ForumQuestionCategoryForUpdate forumQuestionCategoryDto, bool trackChanges);
        Task DeleteOneForumQuestionCategory(int id, bool trackChanges);
    }
}
