using AutoMapper;
using Entities.DataTransferObjects.Categories.DoctorCategory;
using Entities.DataTransferObjects.Category.ArticleCategory;

using Entities.Exceptions.ArticleCategory;
using Entities.Exceptions.Doctor;
using Entities.Exceptions.ProductCategory;
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
    public class ArticleCategoryManager : IArticleCategoryService
    {
        private readonly IRepositoryManager _manager;
        private readonly IMapper _mapper;

        public ArticleCategoryManager(IRepositoryManager manager, IMapper mapper)
        {
            _manager = manager;
            _mapper = mapper;
        }

        public async Task<ArticleCategoryDto> CreateOneArticleCategory(ArticleCategoryDtoForInsertion articleCategoryDto)
        {
            var entity = _mapper.Map<ArticleCategory>(articleCategoryDto);
            //Categoryde category name farklılığı sağlama olayı yapıalcak
            _manager.ArticleCategory.CreateOneArticleCategory(entity);
            await _manager.SaveAsync();
            return _mapper.Map<ArticleCategoryDto>(entity);
        }
        public async Task DeleteOneArticleCategory(int id, bool trackChanges)
        {
            var entity = await _manager.ArticleCategory.GetOneArticleCategoryAsync(id, trackChanges);
            if (entity == null)
            {
                throw new ArticleCategoryNotFoundException(id);
            }

            _manager.ArticleCategory.DeleteOneArticleCategory(entity);
            await _manager.SaveAsync();
        }
        public async Task<IEnumerable<ArticleCategory>> GetAllCategoriesAsync(bool trackChanges)
        {
            return await _manager.ArticleCategory.GetAllArticleCategoriesAsync(trackChanges);

        }
        public async Task UpdateOneArticleCategory(ArticleCategoryDtoForUpdate articleCategory, bool trackChanges)
        {
            var entity = await _manager.ArticleCategory.GetOneArticleCategoryAsync(articleCategory.ArticleCategoryId, trackChanges);
         

         
            if (entity == null)
            {
                throw new ArticleCategoryNotFoundException(articleCategory.ArticleCategoryId);


            }

    
            entity = _mapper.Map<ArticleCategory>(articleCategory);
            _manager.ArticleCategory.Update(entity);
            await _manager.SaveAsync();

        }
    }
}
