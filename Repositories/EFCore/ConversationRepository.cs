using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.EFCore
{
    public class ConversationRepository : RepositoryBase<Conversation>, IConversationRepository
    {
        public ConversationRepository(RepositoryContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Conversation>> GetConversationsByUserIdAsync(string userId)
        {
            return await FindByCondition(c => c.Participant1Id == userId || c.Participant2Id == userId,false)
                .Include(c => c.Messages)
                .ToListAsync();
        }

        public async Task<Conversation> GetByIdAsync(int id)
        {
            return await FindByCondition(c => c.Id == id,false)
                .Include(c => c.Messages)
                .FirstOrDefaultAsync();
        }

        public async  Task CreateConversationAsync(Conversation conversation)
        =>await CreateAsync(conversation);

        public async Task DeleteConversationAsync(Conversation conversation)
        => Delete(conversation);
    }
}
