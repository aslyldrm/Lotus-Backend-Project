using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DataTransferObjects.Appointment
{
    public record class AppointmentDto
    {
        public string UserId { get; set; }
        public string DoctorId { get; set; }
        public DateTime StartTime { get; set; }
    //    public string Status { get; set; }

    }
}
