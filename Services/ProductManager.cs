using AutoMapper;
using Entities.DataTransferObjects.Article;
using Entities.DataTransferObjects.Product;
using Entities.Exceptions.Article;
using Entities.Exceptions.Product;
using Entities.Models;
using Entities.RequestFeatures;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Repositories.Contracts;
using Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class ProductManager : IProductService
    {

        private readonly IRepositoryManager _manager;
        private readonly ILoggerService _logger;
        private readonly IMapper _mapper;
        private readonly UserManager<User> _userManager;
        public ProductManager(IRepositoryManager manager, ILoggerService logger, IMapper mapper, UserManager<User> userManager)
        {
            _manager = manager;
            _logger = logger;
            _mapper = mapper;
            _userManager = userManager;
        }

        public async Task<ProductDto> CreateOneProductAsync(ProductDtoForInsertion productDto)
        {
            var entity = _mapper.Map<Product>(productDto);
            _manager.Product.CreateOneProduct(entity);
            await _manager.SaveAsync();
            return _mapper.Map<ProductDto>(entity);
        }

        public async Task DeleteOneProductAsync(int id, bool trackChanges)
        {
            //checking entity
            var entity = await _manager.Product.GetOneProductByIdAsync(id, trackChanges);
            if (entity == null)
            {
                throw new ProductNotFoundException(id);
            }

            _manager.Product.DeleteOneProduct(entity);
            await _manager.SaveAsync();
        }

        public async Task<(IEnumerable<Product> products, MetaData metaData)> GetAllProductsAsync(ProductParameters productParameters, bool trackChanges)
        {
            var productsWitMetaData = await _manager.Product.
                GetAllProductsAsync(productParameters,trackChanges);

            var productsDto = _mapper.Map<IEnumerable<Product>>(productsWitMetaData);

            return (productsDto,productsWitMetaData.MetaData);
        }

        public async Task<IEnumerable<Product>> GetFilteredProductsAsync(ProductFilterParameters filterParams, bool trackChanges)
        {
            return await _manager.Product.GetFilteredProductsAsync(filterParams, trackChanges);
        }

        public async Task<ProductDto> GetOneProductByIdAsync(int id, bool trackChanges)
        {
            var product = await _manager.Product.GetOneProductByIdAsync(id, trackChanges);


            if (product == null)
                throw new ProductNotFoundException(id);

            return _mapper.Map<ProductDto>(product);
        }
        public async Task<ProductDtoWithDetails> GetOneProductByIdWithDetailsAsync(int id, bool trackChanges)
        {
            var product = await _manager.Product.GetOneProductByIdAsync(id, trackChanges);

            if (product == null)
                throw new ProductNotFoundException(id);

            var productDto = _mapper.Map<ProductDtoWithDetails>(product);

            // Ürün resimlerini al
            var images = await _manager.ProductImage.GetProductImagesAsync(productDto.Id);
            productDto.ProductImages = images;

            // Ürün sahibinin adını al
            var owner = await _userManager.FindByIdAsync(productDto.OwnerId);
            productDto.OwnerName = owner?.UserName;

            return productDto;
        }

        public  async Task UpdateOneProductAsync(int id, ProductDtoForUpdate productDto, bool trackChanges)
        {
            //checking entity
            var entity = await _manager.Product.GetOneProductByIdAsync(id, trackChanges);
            if (entity == null)
            {

                throw new ProductNotFoundException(id);
            }

            entity = _mapper.Map<Product>(productDto);
            _manager.Product.Update(entity);
            await _manager.SaveAsync();
        }

        public async Task<IEnumerable<ProductGetAllWithPictures>> SearchProductsByNameAsync(string productName, bool trackChanges)
        {
            var productsQuery = _manager.Product.FindAll(trackChanges);

            if (!string.IsNullOrWhiteSpace(productName))
            {
                productName = productName.ToLower();
                productsQuery = productsQuery.Where(p => p.ProductName.ToLower().Contains(productName));
            }

            var products = await productsQuery
                .Include(x => x.ProductCategory)
                .ToListAsync();

            var productDtos = _mapper.Map<IEnumerable<ProductGetAllWithPictures>>(products);

            foreach (var productDto in productDtos)
            {
                var images = await _manager.ProductImage.GetProductImagesAsync(productDto.Id);
                productDto.ProductImages = images;
            }

            return productDtos;
        }

        public async Task<IEnumerable<ProductGetAllWithPictures>> GetAllProductsWithPicturesAsync(ProductFilterParameters productParameters, bool trackChanges)
        {
            var products = await this.GetFilteredProductsAsync(productParameters, trackChanges);
            var productDtos = _mapper.Map<IEnumerable<ProductGetAllWithPictures>>(products);
            foreach (var productDto in productDtos)
            {
                // Ürün resimlerini al
                var images = await _manager.ProductImage.GetProductImagesAsync(productDto.Id);
                productDto.ProductImages = images;

                // Ürün sahibinin adını al
                var owner = await _userManager.FindByIdAsync(productDto.OwnerId);
                productDto.OwnerName = owner?.UserName;
            }

            //foreach (var productDto in productDtos)
            //{
            //    var images = await _manager.ProductImage.GetProductImagesAsync(productDto.Id);
            //    productDto.ProductImages = images;
            //}

            return productDtos;
        }

        public async Task<IEnumerable<ProductGetAllWithPictures>> GetProductsByOwnerIdAsync(string userId, bool trackChanges)
        {
            var products = await _manager.Product.FindByCondition(p => p.OwnerId == userId, trackChanges)
                                                 .Include(p => p.ProductCategory)
                                                 .ToListAsync();

            var productDtos = _mapper.Map<IEnumerable<ProductGetAllWithPictures>>(products);

            foreach (var productDto in productDtos)
            {
                var images = await _manager.ProductImage.GetProductImagesAsync(productDto.Id);
                productDto.ProductImages = images;
            }

            return productDtos;
        }

    }
}
