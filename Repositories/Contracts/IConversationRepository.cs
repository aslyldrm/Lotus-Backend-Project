using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Contracts
{
    public interface IConversationRepository  :IRepositoryBase<Conversation>
    {
        Task<IEnumerable<Conversation>> GetConversationsByUserIdAsync(string userId);
        Task<Conversation> GetByIdAsync(int id);
        Task CreateConversationAsync(Conversation conversation);
        Task DeleteConversationAsync(Conversation conversation);
    }
}
