using Entities.DataTransferObjects.Forum;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
using Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentation.Controllers
{
    [ApiController]
    [Route("api/forumQuestions")]
    public class ForumQuestionsController : ControllerBase
    {
        private readonly IServiceManager _services;

        public ForumQuestionsController(IServiceManager services)
        {
            _services = services;
        }
        [HttpGet("GetAllQuestions")]
        public async Task<IActionResult> GetAllForumQuestions()
        {
            return Ok(await _services.ForumService
                .GetAllForumAsync(false));
        }

        [HttpGet("GetOneQuestionByIdWithAnswers/{id}")]
        public async Task<IActionResult> GetOneQuestionByIdWithAnswers(int id)
        {
            var question = await _services.ForumService
                .GetOneForumByIdAsync(id, false);
            var answers = await _services.ForumQuestionAnswerService.GetAnswersByQuestionIdAsync(id, false);
            return Ok(new
            {
                Question = question,
                Answers = answers
            });
        }


        [HttpPost]
        public async Task<IActionResult> CreateOneForumQuestionAsync(
            [FromBody] ForumDtoForInsertion forumDtoInsertion)
        {
             await _services.ForumService
                .CreateOneForum(forumDtoInsertion);
        
            return Ok();
        }

        [HttpPut("questionId:int")]
        public async Task<IActionResult> UpdateOneForumQuestionAsync([FromRoute(Name = "questionId")] int questionId,
            [FromBody] ForumDtoForUpdate forumDto)
        {
            if (forumDto == null)
                return NotFound();
            if (!ModelState.IsValid)
                return UnprocessableEntity(ModelState);

         

            await _services.ForumService.UpdateOneForum(questionId, forumDto, false);

            return Ok(forumDto); //204
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteOneForumAsync([FromRoute(Name = "id")] int id)
        {


            await _services.ForumService.DeleteOneForumQuestion(id, false);

            return NoContent();
        }
    }
}
