using Entities.DataTransferObjects.Conversation;
using Entities.DataTransferObjects.Message;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Contracts
{
    public interface IMessageService
    {
        Task<IEnumerable<ConversationDto>> GetConversationsAsync(string userId);
        Task<ConversationDto> GetConversationByIdAsync(int conversationId);
        Task<Message> SendUserMessageAsync(MessageDto messageDto);
        Task<Message> SendDoctorMessageAsync(MessageDto messageDto);
        Task DeleteMessageAsync(int messageId);
        Task<IEnumerable<ConversationDto>> GetConversationsAsync(string participant1Id, string participant2Id);
        Task DeleteConversationMessageAsync(int conversationId);
    }
}
