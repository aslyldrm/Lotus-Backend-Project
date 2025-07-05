using Entities.DataTransferObjects.ForumAnswers;
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
    [Route("api/forumQuestionAnswers")]
    public class ForumQuestionAnswersController  : ControllerBase
    {
        private readonly IServiceManager _service;

        public ForumQuestionAnswersController(IServiceManager service)
        {
            _service = service;
        }

        [HttpGet("{questionId}/answers")]
        public async Task<IActionResult> GetAnswersByQuestionId(int questionId)
        {
            var answers = await _service.ForumQuestionAnswerService.GetAnswersByQuestionIdAsync(questionId, trackChanges: false);
            return Ok(answers);
        }

        [HttpGet("{questionId}/answers/{answerId}", Name = "GetAnswerById")]
        public async Task<IActionResult> GetAnswerById(int questionId, int answerId)
        {
            var answer = await _service.ForumQuestionAnswerService.GetOneForumQuestionAnswerByIdAsync(questionId, answerId, trackChanges: false);
            if (answer == null)
            {
                return NotFound();
            }
            return Ok(answer);
        }

        [HttpPost("answers")]
        public async Task<IActionResult> CreateAnswer([FromBody] ForumAnswerDtoForInsertion answerDto)
        {
            if (answerDto == null)
            {
                return BadRequest("Bir cevap yazılmadı");
            }

            var createdAnswer = await _service.ForumQuestionAnswerService.CreateOneForumQuestionAnswer(answerDto);

            // Burada QuestionId ve Id özelliklerini doğrudan kullanmıyoruz
            return Ok(createdAnswer);
        }

        [HttpPut("{questionId}/answers/{answerId}")]
        public async Task<IActionResult> UpdateAnswer(int questionId, int answerId, [FromBody] ForumAnswerDtoForUpdate answerDto)
        {
            if (answerDto == null)
            {
                return BadRequest("AnswerDto object is null");
            }

            await _service.ForumQuestionAnswerService.UpdateOneForumQuestionAnswer(questionId, answerId, answerDto, trackChanges: true);
            return NoContent();
        }

        [HttpDelete("{questionId}/answers/{answerId}")]
        public async Task<IActionResult> DeleteAnswer(int questionId, int answerId)
        {
            await _service.ForumQuestionAnswerService.DeleteOneForumQuestionAnswer(questionId, answerId, trackChanges: false);
            return NoContent();
        }
    }
}
