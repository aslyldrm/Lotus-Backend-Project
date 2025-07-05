using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Exceptions.Forum
{
    public class ForumNotFoundException : NotFoundException
    {
        public ForumNotFoundException(int id) : base($"The Forum with id : {id} could not found.")
        {
        }
    }
}
