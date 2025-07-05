using Entities.DataTransferObjects.Forum;
using Entities.DataTransferObjects.ForumAnswers;
using Entities.DataTransferObjects.ForumQuestion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DataTransferObjects
{
    public class ModerationResultDto
    {
        public IEnumerable<ModerationForumUserDetails> InappropriateQuestions { get; set; }
        public IEnumerable<ForumAnswerDtoForControl> InappropriateAnswers { get; set; }
    }
}
