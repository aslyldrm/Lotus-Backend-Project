using System.ComponentModel.DataAnnotations;

namespace Entities.DataTransferObjects.User
{
    public record UserDtoForRegistration {


        [Required(ErrorMessage = "Mail is a required field")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Name is a required field")]

        public string UserName { get; set; }

        [Required(ErrorMessage = "Surname is a required field")]
        public string Surname { get; set; }

        [Required(ErrorMessage = "Password is a required field")]
        public string Password { get; set; }

       // public ICollection<string> Roles { get; init; }

    }





}
