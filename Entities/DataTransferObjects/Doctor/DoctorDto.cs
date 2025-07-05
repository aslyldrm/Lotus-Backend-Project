using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DataTransferObjects.Doctor
{
    public record class DoctorDto
    {
        public string UserId { get; init; }
        public string UserName { get; init; }
        public string Surname { get; set; }
        public string Email { get; init; }
        public  int DoctorCategoryId { get; init; }
        public string Information { get; init; }
        public string Image { get; init; }

    }
}
