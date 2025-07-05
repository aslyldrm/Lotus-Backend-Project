using Entities.Models;
using Repositories.EFCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Contracts
{
    public interface IMessageRepository  :IRepositoryBase<Message>
    {

        Task CreateMessageAsync(Message message);
        Task<Message> GetByIdAsync(int messageId);
        Task DeleteMessageAsync(Message message);


    }
}
