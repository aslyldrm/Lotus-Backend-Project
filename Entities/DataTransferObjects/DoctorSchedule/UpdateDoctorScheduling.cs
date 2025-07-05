using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DataTransferObjects.DoctorSchedule
{
    public record class UpdateDoctorScheduling
    {
        public DateTime AvailableFrom { get; init; }
        public DateTime AvailableTo { get; init; }
       
       
    }
}
