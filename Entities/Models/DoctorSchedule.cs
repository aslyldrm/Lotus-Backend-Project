using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models
{
    public class DoctorSchedule
    {
        public int Id { get; set; }
        public string DoctorId { get; set; }
        public DateTime AvailableFrom { get; set; }
        public DateTime AvailableTo { get; set; }
        public Doctor Doctor { get; set; }
    }
}
