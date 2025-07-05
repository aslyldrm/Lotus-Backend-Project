using AutoMapper;

using Entities.DataTransferObjects.Category.ForumQuestionCategory;
using Entities.Exceptions.ArticleCategory;
using Entities.Exceptions.ForumQuestionCategory;
using Entities.Models.Categories;
using Repositories.Contracts;
using Services.Contracts.Categories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class ForumQuestionCategoryManager : IForumQuestionCategoryService
    {
        private readonly IRepositoryManager _manager;
        private readonly IMapper _mapper;

        public ForumQuestionCategoryManager(IRepositoryManager manager, IMapper mapper)
        {
            _manager = manager;
            _mapper = mapper;
        }

        public async Task<ForumQuestionCategoryDto> CreateOneForumQuestionCategory(ForumQuestionCategoryDtoForInsertion forumQuestionCategoryDto)
        {

            var entity = _mapper.Map<ForumQuestionCategory>(forumQuestionCategoryDto);
            var productCategories = _manager.ForumQuestionCategory.GetAllForumQuestionCategoriesAsync(false);
            foreach (var item in await productCategories)
            {
                if (item.ForumQuestionCategoryName.Equals(forumQuestionCategoryDto.ForumQuestionCategoryName, StringComparison.CurrentCultureIgnoreCase))
                {
                    return null;

                }
            }
            _manager.ForumQuestionCategory.CreateOneForumQuestionCategory(entity);
            await _manager.SaveAsync();
            return _mapper.Map<ForumQuestionCategoryDto>(entity);
        }
        public async Task DeleteOneForumQuestionCategory(int id, bool trackChanges)
        {
            var entity = await _manager.ForumQuestionCategory.GetOneForumQuestionCategoryAsync(id, trackChanges);
            if (entity == null)
            {
                throw new ForumQuestionCategoryNotFoundException(id);
            }

            _manager.ForumQuestionCategory.DeleteOneForumQuestionCategory(entity);
            await _manager.SaveAsync();
        }

        public async Task<IEnumerable<ForumQuestionCategory>> GetAllCategoriesAsync(bool trackChanges)
        {
            return await _manager.ForumQuestionCategory.GetAllForumQuestionCategoriesAsync(trackChanges);

        }

        public async Task UpdateOneForumQuestionCategory(ForumQuestionCategoryForUpdate forumQuestionCategoryDto, bool trackChanges)
        {
            var entity = await _manager.ForumQuestionCategory.GetOneForumQuestionCategoryAsync(forumQuestionCategoryDto.ForumQuestionCategoryId, trackChanges);
            if (entity == null)
            {
                throw new ForumQuestionCategoryNotFoundException(forumQuestionCategoryDto.ForumQuestionCategoryId);


            }
            entity = _mapper.Map<ForumQuestionCategory>(forumQuestionCategoryDto);
            _manager.ForumQuestionCategory.Update(entity);
            await _manager.SaveAsync();
        }
    }
}
