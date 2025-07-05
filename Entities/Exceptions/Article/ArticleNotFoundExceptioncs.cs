using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Exceptions.Article
{
    public class ArticleNotFoundExceptions : NotFoundException
    {
        public ArticleNotFoundExceptions(int id) : base($"The Article with id : {id} could not found.")
        {
        }


    }
}
