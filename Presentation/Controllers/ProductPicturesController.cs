using Entities.DataTransferObjects.Product;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services;
using Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApi.Utilities.AzureBlobForProduct;

namespace Presentation.Controllers
{
    [ApiController]
    [Route("api/productPictures")]
    public class ProductPicturesController : ControllerBase
    {
        private readonly IServiceManager _services;
        private readonly ProductPictureBlobStorageService productPictureBlobStorageService;


        public ProductPicturesController(IServiceManager services, ProductPictureBlobStorageService productPictureBlobStorageService)
        {
            _services = services;
            this.productPictureBlobStorageService = productPictureBlobStorageService;
        }

        [HttpGet("{productId}/images")]
        public async Task<IActionResult> GetProductImages(int productId)
        {
            var images = await _services.ProductImageService.GetProductImagesAsync(productId);
            return Ok(images);
        }

       

        [HttpPost("{productId}/images")]
        public async Task<IActionResult> AddProductImage(int productId, IFormFile file)
        {
            if (file == null || file.Length == 0)
                return BadRequest("No file uploaded.");

            using (var stream = file.OpenReadStream())
            {
                var image = await _services.ProductImageService.AddProductImageAsync(productId, stream, file.FileName);
                return Ok(image);
            }
        }

        [HttpPut("images/{id}")]
        public async Task<IActionResult> UpdateProductImage(int id, IFormFile file)
        {
            if (file == null || file.Length == 0)
                return BadRequest("No file uploaded.");

            using (var stream = file.OpenReadStream())
            {
                await _services.ProductImageService.UpdateProductImageAsync(id, stream);
                return NoContent();
            }
        }

        [HttpDelete("images/{id}")]
        public async Task<IActionResult> DeleteProductImage(int id)
        {
            await _services.ProductImageService.DeleteProductImageAsync(id);
            return NoContent();
        }

       

    }

}