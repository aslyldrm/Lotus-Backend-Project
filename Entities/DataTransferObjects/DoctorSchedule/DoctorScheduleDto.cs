using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DataTransferObjects.DoctorSchedule
{
    public record class DoctorScheduleDto
    {
       // public int Id { get; init; }
        public string DoctorId { get; init; }
        public DateTime AvailableFrom { get; init; }
        public DateTime AvailableTo { get; init; }
        public int AppointmentDurationInMinutes { get; init; }
        public int BreakMinutes { get; init; }
    }
}
