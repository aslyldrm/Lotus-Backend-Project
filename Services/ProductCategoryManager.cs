using AutoMapper;
using Entities.DataTransferObjects.Category.ProductCategory;
using Entities.Exceptions.ProductCategory;
using Entities.Exceptions.User;
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
    public class ProductCategoryManager : IProductCategoryService
    {
        private readonly IRepositoryManager _manager;
        private readonly IMapper _mapper;

        public ProductCategoryManager(IRepositoryManager manager, IMapper mapper)
        {
            _manager = manager;
            _mapper = mapper;
        }

        public async Task<ProductCategoryDto> CreateOneProductCategory(ProductCategoryDtoInsertion productCategory)
        {
            var entity = _mapper.Map<ProductCategory>(productCategory);
            var productCategories =  _manager.ProductCategory.GetAllProductCategoriesAsync(false);
            foreach (var item in await productCategories)
            {
                if (item.ProductCategoryName.Equals(productCategory.productCategoryName, StringComparison.CurrentCultureIgnoreCase))
                {
                    return null;
                    
                }
            }

            
            _manager.ProductCategory.CreateOneProductCategory(entity);
            await _manager.SaveAsync();
            return _mapper.Map<ProductCategoryDto>(entity);
        }

        public async Task DeleteOneProductCategory(int id, bool trackChanges)
        {
            var entity = await _manager.ProductCategory.GetOneProductCategoryAsync(id, trackChanges);
            if(entity == null) {
                throw new ProductCategoryNotFoundException(id);
            }

            _manager.ProductCategory.DeleteOneProductCategory(entity);
            await _manager.SaveAsync();
        }

        public async Task<IEnumerable<ProductCategory>> GetAllCategoriesAsync(bool trackChanges)
        {
            return await _manager.ProductCategory.GetAllProductCategoriesAsync(trackChanges);

        }

        public async Task UpdateOneProductCategory(ProductCategoryDtoUpdate productCategoryDto, bool trackChanges) 
        {
            var entity = await _manager.ProductCategory.GetOneProductCategoryAsync(productCategoryDto.ProductCategoryId, trackChanges);
            if (entity == null)
            {
                throw new ProductCategoryNotFoundException(productCategoryDto.ProductCategoryId);

              
            }
            entity = _mapper.Map<ProductCategory>(productCategoryDto);
            _manager.ProductCategory.Update(entity);
            await _manager.SaveAsync();
        }
    }
}
