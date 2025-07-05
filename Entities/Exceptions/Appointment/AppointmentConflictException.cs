using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Exceptions.Appointment
{
    public class AppointmentConflictException : Exception
    {
        public AppointmentConflictException(String doctor, DateTime context) : base($"Doktor  {context.Date} tarihinde {context.Hour} saatinde doludur. ")
        {
        }
    }
}
