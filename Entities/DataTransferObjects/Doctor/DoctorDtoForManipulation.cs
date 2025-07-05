using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DataTransferObjects.Doctor
{
    public record class DoctorDtoForManipulation
    {
        public int DoctorCategoryId { get; init; }
        public string? Information { get; init; }
       

    }
}
