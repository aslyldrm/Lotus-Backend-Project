using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DataTransferObjects.Appointment
{
    public record class AppointmentDetailsDto
    {
        public int AppointmentId { get; init; }
        public DateTime StartTime { get; init; }
       // public string UserId { get; set; }
   //     public string Username { get; set; }
        public DateTime EndTime { get; init; }
        public string Status { get; init; }
        public string DoctorName { get; init; }
        public int DoctorCategoryId { get; init; }
        public string DoctorCategoryName { get; init; }
    }
}
