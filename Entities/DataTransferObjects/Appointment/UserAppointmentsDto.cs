using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DataTransferObjects.Appointment
{
    public record class UserAppointmentsDto
    {
        public string UserId { get; init; }
        public string UserName { get; init; }
        public string Surname { get; init; }
        public string Email { get; init; }
        public List<AppointmentDetailsDto> Appointments { get; set; }
    }
}
