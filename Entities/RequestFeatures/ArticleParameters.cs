namespace Entities.RequestFeatures
{
    public class ArticleParameters : RequestFeatures
    {
      
        public int? ArticleCategoryId { get; set; }
        public bool SortByAlphabetical { get; set; }
        public bool SortByAlphabeticalDescending { get; set; }
        public bool SortByDate { get; set; }
        public bool SortByDateAscending { get; set; }
    }


    }
