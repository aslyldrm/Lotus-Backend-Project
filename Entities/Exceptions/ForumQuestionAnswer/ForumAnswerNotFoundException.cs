using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Exceptions.ForumQuestionAnswer
{
    public class ForumAnswerNotFoundException : NotFoundException
    {
        public ForumAnswerNotFoundException(int answerId) : base($"The Forum Answer with id : {answerId} could not found.")
        {
        }
    }
}
