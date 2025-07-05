using System.ComponentModel.DataAnnotations;


namespace Entities.Models.Categories
{
    public class ForumQuestionCategory
    {
        [Key]
        public int ForumQuestionCategoryId { get; set; }
        public String? ForumQuestionCategoryName { get; set; }
    }
}
