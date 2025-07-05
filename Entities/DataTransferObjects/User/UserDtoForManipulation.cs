using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DataTransferObjects.User
{
    public record class UserDtoForManipulation
    {
     
        public string? Username { get; init; }
       

        public string? Surname { get; init; }
    
        public string? PregnancyStatus { get; init; }
     
        public string? Email { get; init; }

        public IFormFile? Image { get; set; }


    }
}
