using Entities.Models;
using Entities.Models.Categories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Contracts.Categories
{
    public interface IProductCategoryRepository : IRepositoryBase<ProductCategory>
    {
        Task<IEnumerable<ProductCategory>> GetAllProductCategoriesAsync(bool trackChanges);

        void CreateOneProductCategory(ProductCategory category);
        void UpdateOneProductCategory(ProductCategory category);
        void DeleteOneProductCategory(ProductCategory category);

        Task<ProductCategory> GetOneProductCategoryAsync(int id, bool trackChanges);
    }
}
