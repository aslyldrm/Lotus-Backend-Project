using Entities.DataTransferObjects.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DataTransferObjects.Appointment
{
    public record class TimeSlotDto
    {
        public int ScheduleId { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public bool IsBooked { get; set; }

        public string DoctorNameSurname { get; set; }
        public string DoctorCategoryName { get; set; }
        public int? AppointmentId { get; set; }
        public UserDto? User { get; set; }

    }
}
