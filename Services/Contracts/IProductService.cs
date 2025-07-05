using Entities.DataTransferObjects.Article;
using Entities.DataTransferObjects.Product;
using Entities.Models;
using Entities.RequestFeatures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Contracts
{
    public interface IProductService
    {
        //TODO
        Task<(IEnumerable<Product> products, MetaData metaData)> GetAllProductsAsync(ProductParameters productParameters,bool trackChanges);
        Task<ProductDto> GetOneProductByIdAsync(int id, bool trackChanges);
        Task<ProductDto> CreateOneProductAsync(ProductDtoForInsertion productDto);
        Task UpdateOneProductAsync(int id, ProductDtoForUpdate productDto, bool trackChanges);
        Task DeleteOneProductAsync(int id, bool trackChanges);
        Task<IEnumerable<Product>> GetFilteredProductsAsync(ProductFilterParameters filterParams, bool trackChanges);
        Task<IEnumerable<ProductGetAllWithPictures>> SearchProductsByNameAsync(string productName, bool trackChanges);
        Task<IEnumerable<ProductGetAllWithPictures>> GetAllProductsWithPicturesAsync(ProductFilterParameters productParameters, bool trackChanges);
        Task<IEnumerable<ProductGetAllWithPictures>> GetProductsByOwnerIdAsync(string userId, bool trackChanges);
        Task<ProductDtoWithDetails> GetOneProductByIdWithDetailsAsync(int id, bool trackChanges);

    }
}
