using Entities.DataTransferObjects.Category.ArticleCategory;
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
    [Route("api/articleCategories")]
    public class ArticleCategoriesController : ControllerBase
    {
        private readonly IServiceManager _services;

        public ArticleCategoriesController(IServiceManager services)
        {
            _services = services;
        }


        [HttpGet]
        public async Task<IActionResult> GetAllArticleCategories()
        {
            return Ok(await _services.ArticleCategoryService
                .GetAllCategoriesAsync(false));
        }


        [HttpPost]
        public async Task<IActionResult> CreateOneArticleCategoryAsync(
            [FromBody] ArticleCategoryDtoForInsertion articleCategoryDtoInsertion)
        {
            var articleCategory = await _services.ArticleCategoryService
                .CreateOneArticleCategory(articleCategoryDtoInsertion);
            return Ok(articleCategory);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateOneArticleCategoryAsync(
       [FromBody] ArticleCategoryDtoForUpdate articleCategory)
        {

       
            if (!ModelState.IsValid)
                return UnprocessableEntity(ModelState);

        

            await _services.ArticleCategoryService.UpdateOneArticleCategory(articleCategory, false);

            return Ok(); //204
        }
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteOneArticleCategoryAsync([FromRoute(Name = "id")] int id)
        {


            await _services.ArticleCategoryService.DeleteOneArticleCategory(id, false);

            return NoContent();
        }
    }
}
