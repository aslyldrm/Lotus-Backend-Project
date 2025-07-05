using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Exceptions.User
{
    public class NotFoundFetusPicture : NotFoundException
    {
        public NotFoundFetusPicture(string message) : base(message)
        {
        }
    }
}
