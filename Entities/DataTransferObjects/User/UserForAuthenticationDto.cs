﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DataTransferObjects.User
{
    public record UserForAuthenticationDto
    {
        [Required(ErrorMessage ="Mail is required")]
        public string? Email { get; init; }
        [Required(ErrorMessage = "Password is required")]

        public string Password { get; init; }
    }
}
