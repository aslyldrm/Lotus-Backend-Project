using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Exceptions.Appointment
{
    public class AppointmentNotFoundException : NotFoundException
    {
        public AppointmentNotFoundException(int id) : base($"Bu Id'de bir : {id} randevu bulunamadı")
        {
        }
    }
}
