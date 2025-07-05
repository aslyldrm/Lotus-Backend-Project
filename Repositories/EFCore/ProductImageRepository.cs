using Entities.Models;
using Entities.Models.Categories;
using Microsoft.EntityFrameworkCore;
using Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.EFCore
{
    public class ProductImageRepository : RepositoryBase<ProductImage>, IProductImageRepository
    {
        public ProductImageRepository(RepositoryContext context) : base(context)
        {
        }

        public  async Task AddProductImageAsync(ProductImage productImage)
        

            => await CreateAsync(productImage);
        
        

        //_dbContext.ProductImages.Add(productImage);
        //await _dbContext.SaveChangesAsync();


        public async Task DeleteProductImageAsync(ProductImage productImage)
         => Delete(productImage);

        public async Task<ProductImage> GetProductImageAsync(int productId, string fileName)
        
           
           => await FindByCondition(pi => pi.ProductId == productId && pi.ImageUrl.EndsWith(fileName), false).FirstOrDefaultAsync();

        public async Task<ProductImage> GetProductImageByIdAsync(int id)
        {
            return await FindByCondition(pi => pi.Id == id, trackChanges: false).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<ProductImage>> GetProductImagesAsync(int productId)
         => await FindByCondition(pi => pi.ProductId == productId, false).ToListAsync();

        public Task UpdateProductImageAsync(ProductImage productImage)
         => UpdateAsync(productImage);
    }
}
