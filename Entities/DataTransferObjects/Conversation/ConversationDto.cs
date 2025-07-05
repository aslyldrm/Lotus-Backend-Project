using Entities.DataTransferObjects.Message;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DataTransferObjects.Conversation
{
    public record class ConversationDto
    {
       
       
        public DateTime CreatedAt { get; init; }
        public ICollection<GetMessageDto> Messages { get;  set; }
    }
}
