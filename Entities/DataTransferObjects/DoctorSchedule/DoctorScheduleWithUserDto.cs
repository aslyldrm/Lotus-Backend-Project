using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DataTransferObjects.DoctorSchedule
{
    public record class DoctorScheduleWithUserDto
    {
        public string DoctorId { get; set; }
        public DateTime AvailableFrom { get; set; }
        public DateTime AvailableTo { get; set; }
        public int AppointmentDurationInMinutes { get; set; }
        public string UserId { get; set; }
        public string Username { get; set; }
        public string Surname { get; set; }
        public string PregnancyStatus { get; set; }
    }
}
