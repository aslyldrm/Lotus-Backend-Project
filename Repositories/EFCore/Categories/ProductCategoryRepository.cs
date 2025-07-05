using Entities.Models.Categories;
using Microsoft.EntityFrameworkCore;
using Repositories.Contracts.Categories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.EFCore.Categories
{

    public class ProductCategoryRepository : RepositoryBase<ProductCategory>, IProductCategoryRepository
    {
        public ProductCategoryRepository(RepositoryContext context) : base(context)
        {
        }

        public void CreateOneProductCategory(ProductCategory category) =>
            Create(category);


        public void DeleteOneProductCategory(ProductCategory category) =>
            Delete(category);


        public async Task<IEnumerable<ProductCategory>> GetAllProductCategoriesAsync(bool trackChanges) =>
            await FindAll(trackChanges)
            .OrderBy(c => c.ProductCategoryName)
            .ToListAsync();

        public async Task<ProductCategory> GetOneProductCategoryAsync(int id, bool trackChanges) =>
            await FindByCondition(c => c.ProductCategoryId.Equals(id), trackChanges)
            .SingleOrDefaultAsync();


        public void UpdateOneProductCategory(ProductCategory category) =>
            Update(category);

    }
}
