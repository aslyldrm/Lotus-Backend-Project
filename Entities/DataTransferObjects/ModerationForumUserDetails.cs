using Entities.DataTransferObjects.ForumAnswers;
using Entities.DataTransferObjects.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DataTransferObjects
{
    public record class ModerationForumUserDetails
    {
        public int QuestionId { get; init; }
        public string UserId { get; init; }
        public UserDtoSmallInfo User { get; set; }
        public int UserType { get; init; }

        public string Question { get; init; }
        public string CreationDate { get; init; }
  
        public IEnumerable<ForumAnswerDtoForControl> Answers { get; set; }
    }
}
