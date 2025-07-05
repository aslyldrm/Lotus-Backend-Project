using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Entities.DataTransferObjects.Forum
{
    public record class ForumDto
    {
        public string UserId { get; init; }
        public int UserType { get; init; }
        public int ForumQuestionCategoryId { get; init; }
        public string Question { get; init; }
       
        public int Anonymous { get; init; } // true anonim false anonim değil
    }
}
