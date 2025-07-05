using Entities.DataTransferObjects.ForumAnswers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DataTransferObjects.ForumQuestion
{
    public record class ForumWithAnswersDto
    {
        public int QuestionId { get; init; }
        public string Question { get; init; }
        public string UserId { get; init; }
        public DateTime CreatedDate { get; init; }
        public IEnumerable<ForumAnswerDto> Answers { get; set; }
    }
}
