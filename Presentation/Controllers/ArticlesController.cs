using Entities.DataTransferObjects.Article;
using Entities.DataTransferObjects.User;
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
    [ApiController]
    [Route("api/articles")]
   
    public class ArticlesController : ControllerBase
    {
        private readonly IServiceManager _manager;

        public ArticlesController(IServiceManager manager)
        {
            _manager = manager;
        }

       // [Authorize]
        //[HttpGet]
        //public async Task<IActionResult> GetAllArticlesAsync()
        //{

          

        //    return Ok(await _manager.ArticleService.GetAllArticlesAsync(false));

        //}
       // [Authorize]
        
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetOneArticleAsync([FromRoute(Name = "id")] int id)
        {
            var article = await _manager
                .ArticleService
                .GetOneArticleByIdAsync(id, false);

            return Ok(article);
        }
       // [Authorize(Roles ="Admin,Doctor")]
       // [ServiceFilter(typeof(ValidationAttributeFilter))]
        [HttpPost]
        public async Task<IActionResult> CreateOneArticleAsync([FromForm] ArticleDtoForInsertion articleDto)
        {
            var article = await _manager.ArticleService.CreateOneArticleAsync(articleDto);

            return StatusCode(201, article);

        }

      //  [Authorize(Roles = "Admin,Doctor")]
        [ServiceFilter(typeof(ValidationAttributeFilter))]
        [HttpPut("{id:int}")]
        public async Task<IActionResult> UpdateOneUserAsync([FromRoute(Name = "id")] int id,
            [FromForm] ArticleDtoForUpdate articleDto)
        {

        
            if (!ModelState.IsValid)
                return UnprocessableEntity(ModelState);

         

            await _manager.ArticleService.UpdateOneArticleAsync(id, articleDto, false);

            return Ok(); //204



        }
      //  [Authorize(Roles = "Admin,Doctor")]
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteOneArticleAsync([FromRoute(Name = "id")] int id)
        {


            await _manager.ArticleService.DeleteOneArticleAsync(id, false);

            return NoContent();
        }


    }
}
