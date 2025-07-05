using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Exceptions.Appointment
{
    public class InvalidAppointmentTimeException : Exception
    {
        public InvalidAppointmentTimeException(string message) : base(message) { }
       
    }
}
