using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Exceptions.ArticleCategory
{
    public class ArticleCategoryNotFoundException : NotFoundException
    {
        public ArticleCategoryNotFoundException(int id) : base($"The Article category with id : {id} not found")
        {
        }
    }
}
