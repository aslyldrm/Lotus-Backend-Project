using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DataTransferObjects.ForumAnswers
{
    public record class ForumAnswerDtoForManipulation
    {
        [Required(ErrorMessage = "Question Id is a required field")]
        public int QuestionId { get; init; }
        [Required(ErrorMessage = "Answer Content is a required field")]
        
        public string AnswerContent { get; init; }
        [Required(ErrorMessage = "User Type is a required field")]
        public int UserType { get; init; }
        [Required]
        public string UserId { get; init; }

    }
}
