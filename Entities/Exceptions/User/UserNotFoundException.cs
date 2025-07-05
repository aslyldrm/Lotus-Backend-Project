namespace Entities.Exceptions
{
    public abstract partial class NotFoundException
    {
        //Burada bu metodun kalıtım yapılmasını engelliyoruz.
        public sealed class UserNotFoundException : NotFoundException
        {
            public UserNotFoundException(string id) : base($"The user with id : {id} could not found.")
            {
            }
        }
    }
}
