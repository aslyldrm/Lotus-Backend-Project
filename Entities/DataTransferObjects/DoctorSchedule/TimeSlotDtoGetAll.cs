using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DataTransferObjects.DoctorSchedule
{
    public record class TimeSlotDtoGetAll
    {
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public bool IsBooked { get; set; }

        public string DoctorNameSurname { get; set; }
        public string DoctorCategoryName { get; set; }
        public string DoctorId { get; set; }
        public int DoctorCategoryId { get; set; }
    }
}
