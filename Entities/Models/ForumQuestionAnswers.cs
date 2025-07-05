using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models
{
    public class ForumQuestionAnswers
    {
        [Key]
        public int AnswerId { get; set; }

        public int QuestionId { get; set; }
        public string UserId { get; set; }
        public string AnswerContent { get; set; }
        //Doctor : 1, User :2
        public int UserType { get; set; }
        public DateTime AnswerDate { get; set; } = DateTime.Now;


        //   public ArticleCategory ArticleCategory { get; set; }
        public Forum? ForumQuestion { get; set; }
    }
}
