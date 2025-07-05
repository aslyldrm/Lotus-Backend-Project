using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Exceptions.ForumQuestionCategory
{
    public class ForumQuestionCategoryNotFoundException : NotFoundException
    {
        public ForumQuestionCategoryNotFoundException(int answerId) : base($"The Forum Answer Category with id : {answerId} could not found.")
        {
        }
    }
}
