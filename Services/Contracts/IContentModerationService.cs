using Entities.DataTransferObjects;
using Entities.DataTransferObjects.Forum;
using Entities.DataTransferObjects.ForumAnswers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Contracts
{
    public interface IContentModerationService
    {
        Task<ModerationResultDto> ModerateContentAsync();
    }
}
