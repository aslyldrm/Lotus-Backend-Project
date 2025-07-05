
using Entities.DataTransferObjects.Category.ForumQuestionCategory;
using Entities.Models;
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
    [Route("api/forumQuestionCategories")]
    public class ForumQuestionCategoriesController : ControllerBase
    {
        private readonly IServiceManager _services;

        public ForumQuestionCategoriesController(IServiceManager services)
        {
            _services = services;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllForumQuestionCategories()
        {
           
            return Ok(await _services.ForumQuestionCategoryService
                .GetAllCategoriesAsync(false));
        }


        [HttpPost]
        public async Task<IActionResult> CreateOneForumQuestionCategoryAsync(
            [FromBody] ForumQuestionCategoryDtoForInsertion articleCategoryDtoInsertion)
        {
            var forumQuestion = await _services.ForumQuestionCategoryService
                .CreateOneForumQuestionCategory(articleCategoryDtoInsertion);
            if (forumQuestion == null)
            {
                return BadRequest("Bu kategori bulunmaktadır. Başka bir kategori deneyiniz");
            }
            return Ok(forumQuestion);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateOneForumQuestionCategoryAsync(
            [FromBody] ForumQuestionCategoryForUpdate forumQuestionCategoryDto)
        {
            if (forumQuestionCategoryDto == null)
                return NotFound();
            if (!ModelState.IsValid)
                return UnprocessableEntity(ModelState);

  
            await _services.ForumQuestionCategoryService.UpdateOneForumQuestionCategory(forumQuestionCategoryDto, false);

            return Ok(forumQuestionCategoryDto); //204
        }
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteOneForumQuestionCategoryAsync([FromRoute(Name = "id")] int id)
        {


            await _services.ForumQuestionCategoryService.DeleteOneForumQuestionCategory(id, false);

            return NoContent();
        }
    }
}
