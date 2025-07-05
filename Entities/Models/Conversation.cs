using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models
{
    public class Conversation
    {
        public int Id { get; set; }
        public string Participant1Id { get; set; }
        public string Participant2Id { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public ICollection<Message> Messages { get; set; }
    }
}
