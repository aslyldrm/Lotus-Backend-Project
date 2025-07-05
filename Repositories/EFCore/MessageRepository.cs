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
    public class MessageRepository : RepositoryBase<Message>, IMessageRepository
    {
        public MessageRepository(RepositoryContext context) : base(context)
        {
        }

        public Task CreateMessageAsync(Message message)
        => CreateAsync(message);


        public async Task<Message> GetByIdAsync(int messageId)
        {
            return await FindByCondition(m => m.Id == messageId,false).FirstOrDefaultAsync();
        }

      

        public Task DeleteMessageAsync(Message message)
        => DeleteAsync(message);
    }
}
