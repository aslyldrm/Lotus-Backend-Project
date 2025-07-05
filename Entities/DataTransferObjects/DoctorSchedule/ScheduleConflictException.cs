using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DataTransferObjects.DoctorSchedule
{
    public class ScheduleConflictException : Exception
    {
        public ScheduleConflictException(string? message) : base(message)
        {
        }
    }
}
