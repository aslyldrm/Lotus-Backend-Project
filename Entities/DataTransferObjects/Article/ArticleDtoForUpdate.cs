using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DataTransferObjects.Article
{
    public record ArticleDtoForUpdate 
    {

   
        
        [MaxLength(50, ErrorMessage = "Title must consist of maximum 50 characters ")]
        public string? Title { get; init; }

      
        public string? ContentText { get; init; }

       
      
        public string? Writers { get; init; }

  
        public int? ArticleCategoryId { get; init; }
        public IFormFile? Image { get; init; }
    }
}
