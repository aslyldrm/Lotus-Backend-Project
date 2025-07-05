using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DataTransferObjects.ForumAnswers
{
    public record class ForumAnswerDto
    {

        public int AnswerId { get; init; }
        public int QuestionId { get; init; }
        public string UserId { get; init; }
        public string AnswerContent { get; init; }
        //Doctor : 1, User :2
        public int UserType { get; init; }

    }
}
