using Entities.Models;
using Entities.Models.Categories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Contracts
{
    public interface IProductImageRepository : IRepositoryBase<ProductImage>
    {
        Task<IEnumerable<ProductImage>> GetProductImagesAsync(int productId);
        Task<ProductImage> GetProductImageByIdAsync(int id);
        Task AddProductImageAsync(ProductImage productImage);
        Task DeleteProductImageAsync(ProductImage productImage);
        Task UpdateProductImageAsync(ProductImage productImage);
    }
}
