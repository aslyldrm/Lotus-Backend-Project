using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DataTransferObjects.Category.ForumQuestionCategory
{
    public record class ForumQuestionCategoryForUpdate : ForumQuestionCategoryDtoForManipulation
    {
        [Required]
        public int ForumQuestionCategoryId { get; init; }
    }
}
