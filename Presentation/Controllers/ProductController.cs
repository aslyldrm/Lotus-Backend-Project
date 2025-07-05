using Entities.DataTransferObjects.Article;
using Entities.DataTransferObjects.Product;
using Entities.RequestFeatures;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Presentation.ActionFilters;
using Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Presentation.Controllers
{

    [Route("api/products")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IServiceManager _manager;

        public ProductController(IServiceManager manager)
        {
            _manager = manager;
        }

        // [Authorize]
       // [HttpGet("GetAllPicturesWith")]
      
        [HttpGet]
        public async Task<IActionResult> GetAllProductsAsync([FromQuery] ProductParameters productParameters)
        {

            var pagedResult = await _manager.ProductService.
                GetAllProductsAsync(productParameters, false);
            
            Response.Headers.Add("X-Pagination",
                JsonSerializer.Serialize(pagedResult.metaData));
            
            return Ok(pagedResult.products);

        }
      //  [Authorize]

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetOneProductAsync([FromRoute(Name = "id")] int id)
        {
            var product = await _manager
                .ProductService
                .GetOneProductByIdWithDetailsAsync(id, false);

            return Ok(product);
        }
       // [Authorize(Roles = "Admin,Doctor")]
        //[ServiceFilter(typeof(ValidationAttributeFilter))]
        [HttpPost]
        public async Task<IActionResult> CreateOneProductAsync([FromBody] ProductDtoForInsertion productDto)
        {
            var product = await _manager.ProductService.CreateOneProductAsync(productDto);

            return StatusCode(201, product);

        }

      //  [Authorize(Roles = "Admin,Doctor")]
        [ServiceFilter(typeof(ValidationAttributeFilter))]
        [HttpPut("{id:int}")]
        public async Task<IActionResult> UpdateOneProductAsync([FromRoute(Name = "id")] int id,
            [FromBody] ProductDtoForUpdate productDto)
        {

            if (productDto == null)
                return NotFound();
            if (!ModelState.IsValid)
                return UnprocessableEntity(ModelState);

            if (id != productDto.Id)
                return BadRequest(); //400

            await _manager.ProductService.UpdateOneProductAsync(id, productDto, false);

            return Ok(productDto); //204



        }
       // [Authorize(Roles = "Admin,Doctor")]
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteOneProductAsync([FromRoute(Name = "id")] int id)
        {

           

            await _manager.ProductService.DeleteOneProductAsync(id, false);

            return NoContent();
        }


    

}
}
