using Entities.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Contracts
{
    public interface IProductImageService
    {
        Task<IEnumerable<ProductImage>> GetProductImagesAsync(int productId);
        Task<ProductImage> GetProductImageByIdAsync(int id);
        Task<ProductImage> AddProductImageAsync(int productId, Stream imageStream, string fileName);
        Task UpdateProductImageAsync(int id, Stream imageStream);
        Task DeleteProductImageAsync(int id);
    }
}
