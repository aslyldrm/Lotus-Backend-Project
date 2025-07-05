using AutoMapper;
using Entities.Models;
using Microsoft.AspNetCore.Http;
using Repositories.Contracts;
using Repositories.EFCore;
using Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApi.Utilities.AzureBlobForProduct;

namespace Services
{
    public class ProductImageService : IProductImageService
    {
        private readonly ProductPictureBlobStorageService _blobStorageService;
        private readonly IRepositoryManager _manager;
      

        public ProductImageService(IRepositoryManager manager, ProductPictureBlobStorageService blobStorageService)
        {
       
            _manager = manager;
            _blobStorageService = blobStorageService;
        }


        public async Task<ProductImage> AddProductImageAsync(int productId, Stream imageStream, string fileName)
        {
            var images = await _manager.ProductImage.GetProductImagesAsync(productId);
            if (images.Count() >= 4)
            {
                throw new InvalidOperationException("A product can have a maximum of 4 images.");
            }

            var imageUrl = await _blobStorageService.UploadBlobAsync(imageStream, fileName);
            var productImage = new ProductImage
            {
                ProductId = productId,
                ImageUrl = imageUrl
            };

            await _manager.ProductImage.AddProductImageAsync(productImage);
            return productImage;
        }


   
        public async Task DeleteProductImageAsync(int id)
        {
            var productImage = await _manager.ProductImage.GetProductImageByIdAsync(id);
            if (productImage == null)
            {
                throw new KeyNotFoundException("Image not found.");
            }

            await _blobStorageService.DeleteBlobAsync(productImage.ImageUrl);
            await _manager.ProductImage.DeleteProductImageAsync(productImage);
            await _manager.SaveAsync();
        }
        public async Task<ProductImage> GetProductImageByIdAsync(int id)
        {
         
            return await _manager.ProductImage.GetProductImageByIdAsync(id);
        }

        public async Task<IEnumerable<ProductImage>> GetProductImagesAsync(int productId)
        {
            return await _manager.ProductImage.GetProductImagesAsync(productId);
        }

        public async Task UpdateProductImageAsync(int id, Stream imageStream)
        {
            var productImage = await _manager.ProductImage.GetProductImageByIdAsync(id);
            if (productImage == null)
            {
                throw new KeyNotFoundException("Image not found.");
            }

            // Eski resmi silmek için eski URL'yi kaydediyoruz
            var oldImageUrl = productImage.ImageUrl;

            // Yeni dosya URL'si oluşturuluyor
            var newImageUrl = await _blobStorageService.UploadBlobAsync(imageStream, oldImageUrl);
            productImage.ImageUrl = newImageUrl;

            await _manager.ProductImage.UpdateProductImageAsync(productImage);

            // Eski resmi sildikten sonra değişiklikleri kaydediyoruz
            await _blobStorageService.DeleteBlobAsync(oldImageUrl);

            await _manager.SaveAsync();
        }

    }
}
