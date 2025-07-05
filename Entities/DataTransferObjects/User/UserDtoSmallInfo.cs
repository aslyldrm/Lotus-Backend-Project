using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DataTransferObjects.User
{
    public class UserDtoSmallInfo
    {
        public string UserName { get; init; }
        public string Email { get; init; }
        public string Surname { get; init; }
        public int UserType { get; init; }
    }
}
