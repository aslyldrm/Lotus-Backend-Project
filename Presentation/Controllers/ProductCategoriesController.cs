using Entities.DataTransferObjects.Category.ProductCategory;
using Entities.DataTransferObjects.Product;
using Microsoft.AspNetCore.Mvc;
using Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentation.Controllers
{
    [ApiController]
    [Route("api/productCategories")]
    public class ProductCategoriesController : ControllerBase
    {
        private readonly IServiceManager _services;

        public ProductCategoriesController(IServiceManager service)
        {
            _services = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllProductCategories()
        {
            return Ok(await _services.ProductCategoryService
                .GetAllCategoriesAsync(false));
        }


        [HttpPost]
        public async Task<IActionResult> CreateOneProductCategoryAsync(
            [FromBody] ProductCategoryDtoInsertion productCategoryDtoInsertion)
        {
            var productCategory = await _services.ProductCategoryService
            
                .CreateOneProductCategory(productCategoryDtoInsertion);
            if (productCategory == null)
            {
                return BadRequest("The Product Category name already exist");
            }
            return Ok(productCategory);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateOneProductCategoryAsync(
            [FromBody] ProductCategoryDtoUpdate productCategoryDto)
        {
            if (productCategoryDto == null)
                return NotFound();
            if (!ModelState.IsValid)
                return UnprocessableEntity(ModelState);

         

            await _services.ProductCategoryService.UpdateOneProductCategory(productCategoryDto, false);

            return Ok(productCategoryDto); //204
        }
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteOneProductCategoryAsync([FromRoute(Name = "id")] int id)
        {


            await _services.ProductCategoryService.DeleteOneProductCategory(id, false);

            return NoContent();
        }
    }
}
