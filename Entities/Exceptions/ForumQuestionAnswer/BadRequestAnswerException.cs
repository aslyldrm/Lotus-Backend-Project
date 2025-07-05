using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Exceptions.ForumQuestionAnswer
{
    public class BadRequestAnswerException : BadRequestException
    {
        public BadRequestAnswerException(string message) : base(message)
        {
        }
    }
}
