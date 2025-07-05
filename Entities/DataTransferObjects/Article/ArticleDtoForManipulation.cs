using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DataTransferObjects.Article
{
    public abstract record ArticleDtoForManipulation
    {
        [Required(ErrorMessage = "Title is a required field")]
        [MinLength(1, ErrorMessage = "Title must consist of at least 1 characters ")]
        [MaxLength(50, ErrorMessage = "Title must consist of maximum 50 characters ")]
        public string Title { get; init; }

        [Required(ErrorMessage = "Content Text is a required field")]
        [MinLength(1, ErrorMessage = "Content Text must consist of at least 1 characters ")]
        public string ContentText { get; init; }

        [Required(ErrorMessage = "Writers is a required field")]
        [MinLength(10, ErrorMessage = "Writers must consist of at least 1 characters ")]
        public string Writers { get; init; }

        [Required(ErrorMessage = "Article Category is a required field")]
        public int ArticleCategoryId { get; init; }

        public IFormFile? Image { get; init; }
    }
}
