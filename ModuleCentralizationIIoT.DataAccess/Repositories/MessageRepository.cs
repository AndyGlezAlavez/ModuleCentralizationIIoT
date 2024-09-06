#region   USINGS
using ModuleCentralizationIIoT.Contracts;
using ModuleCentralizationIIoT.DataAccess.Contexts;
using ModuleCentralizationIIoT.DataAccess.Repositories.Common;
using ModuleCentralizationIIoT.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
#endregion

namespace ModuleCentralizationIIoT.DataAccess.Repositories
{
    public class MessageRepository : RepositoryBase, IMessageRepository
    {
        public MessageRepository(ApplicationContext context) : base(context)  { }

        public void AdddMessage(Message message)  {  _context.Messages.Add(message);   }

        public void DeleteMessage(Message message) { _context.Messages.Remove(message);   }

        public IEnumerable<Message> GetAllMessage() {    return _context.Messages.ToList();    }

        public Message? GetMessageById(Guid id) 
        {
            return _context.Messages.FirstOrDefault(x => x.Id == id);
        }
     
        public void UpdateMessage(Message message)  {  _context.Messages.Update(message);    }
    
    
    }
}
