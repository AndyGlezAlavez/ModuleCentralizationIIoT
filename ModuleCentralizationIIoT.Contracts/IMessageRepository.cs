using ModuleCentralizationIIoT.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModuleCentralizationIIoT.Contracts
{
    public interface IMessageRepository
    {
        void AdddMessage(Message message);
        Message? GetMessageById(Guid id);
        public IEnumerable<Message> GetAllMessage();
        void UpdateMessage(Message message);
        void DeleteMessage(Message message);
    }
}
