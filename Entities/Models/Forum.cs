using Entities.Models.Categories;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Entities.Models
{
    public class Forum
    {
        [Key]
        public int QuestionId { get; set; }
        public string UserId { get; set; }
        public int UserType { get; set; }
        public int ForumQuestionCategoryId { get; set; }
        public string Question { get; set; }
        public DateTime CreationDate { get; set; } = DateTime.Now;
        public int Anonymous { get; set; } // true anonim false anonim değil

        public ForumQuestionCategory? ForumQuestionCategory { get; set; }
    }
}
