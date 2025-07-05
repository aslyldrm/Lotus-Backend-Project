namespace Entities.DataTransferObjects.User
{
    ////[Serializable] If we use this keyword here. In postman Thıs 
    ///part will not be a clear
    //public record UserDto(int Id, String Mail, String Name, String Surname,
    //    String PregnancyStatus, String Image, String Password);


    public record UserDto
    {
        public string Id { get; init; }
        public string UserName { get; init; }
        public string? Image { get; init; }
        public string Surname { get; init; }
        public string FetusPicture { get; init; }
        public string Email { get; init; }
        public bool EmailConfirmed { get; init; }
        public string? PregnancyStatus { get; init; }
        public int UserType { get; init; }


    }





}
