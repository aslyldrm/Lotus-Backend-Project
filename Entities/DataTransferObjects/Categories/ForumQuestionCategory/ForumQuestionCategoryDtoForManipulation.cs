using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DataTransferObjects.Category.ForumQuestionCategory
{
    public record class ForumQuestionCategoryDtoForManipulation
    {
        [Required]
        public string? ForumQuestionCategoryName { get; init; }
    }
}
