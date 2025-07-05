using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DataTransferObjects.Forum
{
    public record class ForumDtoForManipulation
    {
        [Required(ErrorMessage = "User Id is a required field")]
        public string UserId { get; init; }
        [Required(ErrorMessage = "Kategori eklemediniz")]


        public int ForumQuestionCategoryId { get; init; }
        [Required(ErrorMessage = "Soru eklemediniz")]
        public string Question { get; init; }

        public int Anonymous { get; init; }
    }
}
