using Entities.DataTransferObjects.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DataTransferObjects.ForumAnswers
{
    public class ForumAnswerDtoForControl
    {
        public int AnswerId { get; set; }
        public int QuestionId { get; set; }
        public string UserId { get; set; }
        public UserDtoSmallInfo User { get; set; } // Kullanıcı bilgilerini içeren alan
        public string AnswerContent { get; set; }
        public int UserType { get; set; }
    }
}
