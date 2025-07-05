using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DataTransferObjects.Message
{
    public record class MessageDto
    {
       
        //public int ConversationId { get; init; }
        public string SenderId { get; init; }
        public string RecipientId { get; init; }
        public string Text { get; init; }
       // public DateTime SentAt { get; init; }
    }

}
