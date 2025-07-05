using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Exceptions.DoctorSchedule
{
    public class ScheduleNotFoundException : NotFoundException
    {
        public ScheduleNotFoundException(string Id) : base($"The Doctor Schedule with id : {Id} could not found.")
        {
        }
    }
}
