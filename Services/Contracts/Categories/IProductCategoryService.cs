using Entities.DataTransferObjects.Category.ProductCategory;
using Entities.Models;
using Entities.Models.Categories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Contracts.Categories
{
    public interface IProductCategoryService
    {
        Task<IEnumerable<ProductCategory>> GetAllCategoriesAsync(bool trackChanges);
        Task<ProductCategoryDto> CreateOneProductCategory(ProductCategoryDtoInsertion productCategory);
        Task UpdateOneProductCategory(ProductCategoryDtoUpdate productCategoryDto, bool trackChanges);
        Task DeleteOneProductCategory(int id, bool trackChanges);
    }
}
