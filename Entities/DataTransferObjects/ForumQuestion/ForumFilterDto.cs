using Entities.DataTransferObjects.ForumAnswers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DataTransferObjects.ForumQuestion
{
    public record class ForumFilterDto
    {
        public int QuestionId { get; init; }
        public string UserId { get; init; }
        public int UserType { get; init; }
        public int ForumQuestionCategoryId { get; init; }
        public string Question { get; init; }
        public string CreationDate { get; init; }
        public int Anonymous { get; init; }
        public IEnumerable<ForumAnswerDto> Answers { get; set; }
    }
}
