using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models
{
    public class Message
    {
        public int Id { get; set; }
        public int ConversationId { get; set; }
        public Conversation Conversation { get; set; }
        public string SenderId { get; set; }
        public string RecipientId { get; set; }
        public string Text { get; set; }
        public DateTime SentAt { get; set; } = DateTime.Now;
    }

}
