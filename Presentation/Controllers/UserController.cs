using Entities.DataTransferObjects.User;
using Entities.Exceptions.User;
using Entities.Models;
using Microsoft.AspNetCore.Mvc;
using Presentation.ActionFilters;
using Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Entities.Exceptions.NotFoundException;

namespace Presentation.Controllers
{
    [Route("api/user")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IServiceManager _manager;

        public UserController(IServiceManager manager)
        {
            _manager = manager;
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOneUserAsync([FromRoute(Name = "id")] string id)
        {
            var user = await _manager.AuthenticationService.FindByIdAsync(id, false);
            if (user.UserType == 1 || user.UserType == 2)
            {
                return NoContent();
            }

            await _manager.AuthenticationService.DeleteOneUserAsync(id, false);
            return NoContent();
        }



        [HttpGet("{id}")]
        public async Task<IActionResult> GetOneUserAsync([FromRoute(Name = "id")] string id)
        {
            var user = await _manager.AuthenticationService.FindByIdAsync(id, false);

            var user_2 = await _manager.AuthenticationService.FindByIdAsyncForPictures(user.Id, false);
         
            return Ok(user_2);
          
        }

        [ServiceFilter(typeof(ValidationAttributeFilter))]
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateOneUserAsync([FromRoute(Name = "id")] string id,
            [FromForm] UserDtoForUpdate userDto)
        {
            var user = await _manager.AuthenticationService.FindByIdAsync(id, false);
            if (user.UserType == 1 || user.UserType == 2)
            {
                return NoContent();
            }
            await _manager.AuthenticationService.UpdateOneUserAsync(id, userDto, false);

            return Ok();
        }


        [HttpPost("forgot-password")]
        public async Task<IActionResult> ForgotPassword([FromBody] ForgotPasswordDto forgotPasswordDto)
        {
            await _manager.AuthenticationService.SendForgotPasswordEmailAsync(forgotPasswordDto.Email, HttpContext);
            return Ok("Verification code sent.");
        }

        [HttpPost("reset-password")]
        public async Task<IActionResult> ResetPassword([FromBody] ResetPasswordDto resetPasswordDto)
        {
            await _manager.AuthenticationService.ResetPasswordAsync(resetPasswordDto.Email, resetPasswordDto.Code, resetPasswordDto.NewPassword);
            return Ok("Password has been reset.");
        }


        [HttpGet("{userId}/products")]
        public async Task<IActionResult> GetProductsByOwnerId(string userId)
        {
            var products = await _manager.ProductService.GetProductsByOwnerIdAsync(userId, false);
            return Ok(products);
        }


        [HttpGet("{userId}/appointments")]
        public async Task<IActionResult> GetUserAppointments(string userId)
        {
            var appointments = await _manager.AppointmentService.GetUserAppointmentsAsync(userId, false);
            return Ok(appointments);
        }

        [HttpGet("{userId}/forum-questions")]
        public async Task<IActionResult> GetUserForumQuestions(string userId)
        {
            var forumQuestions = await _manager.ForumService.GetUserForumQuestionsAsync(userId, false);
            return Ok(forumQuestions);
        }
    }
}
