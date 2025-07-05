using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Exceptions.Doctor
{
    public class DoctorCategoryNotFoundException : NotFoundException
    {
        public DoctorCategoryNotFoundException(int Id) : base($"Doktor Kategorisi id : {Id} bulunmamaktadır.")
        {
        }
    }
}
