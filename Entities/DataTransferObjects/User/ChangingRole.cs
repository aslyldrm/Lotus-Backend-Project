using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DataTransferObjects.User
{
    public record class ChangingRole
    {
        public string Id { get; init; }
        public string Role { get; init; }
    }
}
