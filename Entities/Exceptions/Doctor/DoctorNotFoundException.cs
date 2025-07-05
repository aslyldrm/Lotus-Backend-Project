using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Exceptions.Doctor
{
    public class DoctorNotFoundException : NotFoundException
    {
        public DoctorNotFoundException(string message) : base(message)
        {
        }
    }
}
