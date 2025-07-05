using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DataTransferObjects.ForumAnswers
{
    public record class ForumAnswerDtoForUpdate 
    {
        [Required(ErrorMessage = "Answer Content is a required field")]
        public string AnswerContent { get; init; }

    }
}
