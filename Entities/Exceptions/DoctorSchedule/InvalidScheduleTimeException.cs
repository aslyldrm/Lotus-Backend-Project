﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Exceptions.DoctorSchedule
{
    public  class InvalidScheduleTimeException : Exception

    {
        public InvalidScheduleTimeException(string message) : base(message)
        {
        }
    }
}
