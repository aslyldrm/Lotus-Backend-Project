using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Entities.Exceptions.User
{
    public class RefreshTokenBadRequestException : BadRequest
    {
        public RefreshTokenBadRequestException()
            : base($"Invalid client request. The tokenDto has some invalid values.")
        {
        }
    }
}
