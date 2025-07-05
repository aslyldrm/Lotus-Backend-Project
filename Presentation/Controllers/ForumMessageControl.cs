using Microsoft.AspNetCore.Mvc;
using OpenAI;

using Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenAI.Chat;
using Entities.RequestFeatures;
using Services;
namespace Presentation.Controllers
{
    [Route("api/control")]
    [ApiController]
    public class ForumMessageControl : ControllerBase
    {
        private readonly IServiceManager _manager;


        public ForumMessageControl(IServiceManager manager)
        {
            _manager = manager;
        }
        [HttpPost("moderateContent")]
        public async Task<IActionResult> ModerateContent()
        {
            var moderationResult = await _manager.ContentModerationService.ModerateContentAsync();
            return Ok(moderationResult);
        }

    }

}
