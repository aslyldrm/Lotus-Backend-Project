namespace Entities.DataTransferObjects.User
{
    public record class ResetPasswordDto
    {
        public string Email { get; init; }
        public string Code { get; init; }
        public string NewPassword { get; init; }
    }
}
