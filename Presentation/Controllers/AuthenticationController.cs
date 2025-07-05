using Entities.DataTransferObjects.User;
using Entities.Exceptions.User;
using Entities.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
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
    [ServiceFilter(typeof(LogFilterAttribute))]
    [Route("api/authentication")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly IServiceManager _manager;
        private readonly ILoggerService _logger;

        public AuthenticationController(IServiceManager manager, ILoggerService logger)
        {
            _manager = manager;
            _logger = logger;
        }

        [HttpPost("registration")]
        [ServiceFilter(typeof(ValidationAttributeFilter))]
        public async Task<IActionResult> RegisterUser([FromBody] UserDtoForRegistration userDtoForRegistration)
        {
            var actionContext = new ActionContext(HttpContext, RouteData, ControllerContext.ActionDescriptor);
            var result = await _manager
                .AuthenticationService
                .RegisterUser(userDtoForRegistration, actionContext);

            if(!result.Succeeded)
            {
                foreach(var error in result.Errors)
                {
                    ModelState.TryAddModelError(error.Code, error.Description);

                }
                return BadRequest(ModelState);
            }

            return StatusCode(201);
        }

        [HttpPost("login")]
        [ServiceFilter(typeof(ValidationAttributeFilter))]
        public async Task<IActionResult> Authenticate([FromBody] UserForAuthenticationDto user)
        {
            if (!await _manager.AuthenticationService.ValidateUser(user))
                return Unauthorized();

            var tokenDto = await _manager
                .AuthenticationService
                .CreateToken(populateExp: true);
            var userObject = await _manager.AuthenticationService.FindingUserByEmail(user.Email);


            return Ok(new
            {
                tokenDto,
                userObject.Id

            });
        }


        [HttpPost("refresh")]
        [ServiceFilter(typeof(ValidationAttributeFilter))]
        public async Task<IActionResult> Refresh([FromBody] TokenDto tokenDto)
        {
            var tokenDtoToReturn = await _manager
                .AuthenticationService
                .RefreshToken(tokenDto);

            return Ok(tokenDtoToReturn);    
        }


        [HttpGet("ConfirmEmail")]
        public async Task<IActionResult> ConfirmEmail(string userId, string code)
        {
            if (userId == null || code == null)
                return Content("User ID and Code must be supplied for email confirmation.","text/plain");

            var user = await _manager.AuthenticationService.FindByIdAsync(userId,false);
            if (user == null)
                return NotFound("User not found.");
            user.EmailConfirmed = true;

            var result = await _manager.AuthenticationService.UpdateUserAsync(user);
           
            if (result.Succeeded)
                return Content("Email confirmed successfully.", "text/plain");

            return Content("Error confirming email.", "text/plain");
        }

        [HttpPut("UpdateRole")]
        public async Task<IActionResult> AddingRole(ChangingRole changingRole)
        {
         
            var result = await _manager.AuthenticationService.UpdateRoles(changingRole.Id,changingRole.Role);
            if (result)
                return Ok("User's roles changed successfully");

            return BadRequest(result);

        }

      
     







    }
}

