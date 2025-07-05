using AutoMapper;
using Entities.DataTransferObjects.Message;
using Microsoft.AspNetCore.Mvc;
using Services.Contracts;
using System;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Presentation.Controllers
{
    [Route("api/messages")]
    [ApiController]
    public class MessagesController : ControllerBase
    {
        private readonly IServiceManager _manager;
        private readonly IMapper _mapper;

        public MessagesController(IServiceManager manager, IMapper mapper)
        {
            _manager = manager;
            _mapper = mapper;
        }

        [HttpGet("conversations/{userId}")]
        public async Task<IActionResult> GetConversations(string userId)
        {
            var conversations = await _manager.MessageService.GetConversationsAsync(userId);
            return Ok(conversations);
        }

        [HttpGet("conversation/{conversationId}")]
        public async Task<IActionResult> GetConversationById(int conversationId)
        {
            var conversation = await _manager.MessageService.GetConversationByIdAsync(conversationId);
            return Ok(conversation);
        }

        [HttpPost("user")]
        public async Task<IActionResult> SendUserMessage([FromBody] MessageDto messageDto)
        {
            if (messageDto == null)
            {
                return BadRequest("MessageDto object is null");
            }

            try
            {
                var createdMessage = await _manager.MessageService.SendUserMessageAsync(messageDto);
                return CreatedAtAction(nameof(GetConversationById), new { conversationId = createdMessage.ConversationId }, _mapper.Map<MessageDto>(createdMessage));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("doctor")]
        public async Task<IActionResult> SendDoctorMessage([FromBody] MessageDto messageDto)
        {
            if (messageDto == null)
            {
                return BadRequest("MessageDto object is null");
            }

            try
            {
                var createdMessage = await _manager.MessageService.SendDoctorMessageAsync(messageDto);
                return CreatedAtAction(nameof(GetConversationById), new { conversationId = createdMessage.ConversationId }, _mapper.Map<MessageDto>(createdMessage));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("message/{messageId}")]
        public async Task<IActionResult> DeleteMessage(int messageId)
        {
          

            try
            {
                await _manager.MessageService.DeleteMessageAsync(messageId);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("conversations")]
        public async Task<IActionResult> GetConversations(string participant1Id, string participant2Id)
        {
            var conversations = await _manager.MessageService.GetConversationsAsync(participant1Id, participant2Id);
            return Ok(conversations);
        }

        [HttpDelete("conversation/{conversationId}")]
        public async Task<IActionResult> DeleteConversation(int conversationId)
        {
            try
            {
                await _manager.MessageService.DeleteConversationMessageAsync(conversationId);
                return Ok(new { Message = "Conversation and its messages deleted successfully." });
            }
            catch (Exception ex)
            {
                return BadRequest(new { Error = ex.Message });
            }
        }
    }
}
