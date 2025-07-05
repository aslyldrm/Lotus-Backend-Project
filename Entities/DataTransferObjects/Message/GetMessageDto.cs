using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DataTransferObjects.Message
{
    public class GetMessageDto
    {
        public int Id { get; set; }
        public int ConversationId { get; init; }
        public string SenderId { get; init; }
        public string RecipientId { get; init; }
        public string Text { get; init; }
        public DateTime SentAt { get; init; }
        // public DateTime SentAt { get; init; }
    }
}
