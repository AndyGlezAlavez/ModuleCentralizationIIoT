#region    USINGS
using ModuleCentralizationIIoT.Application.Abstract;
using ModuleCentralizationIIoT.Contracts;
using ModuleCentralizationIIoT.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
#endregion

namespace ModuleCentralizationIIoT.Application.MessageCQRS.Queries.GetAllMessage
{
    public class GetAllMesssageQueryHandler : IQueryHandler<GetAllMessageQuery, IEnumerable<Message>>
    {
        private readonly IMessageRepository _messageRepository;

        public GetAllMesssageQueryHandler(IMessageRepository messageRepository)
        {
            _messageRepository = messageRepository;
        }

        public Task<IEnumerable<Message>> Handle(GetAllMessageQuery request, CancellationToken cancellationToken)
        {
            return Task.FromResult(_messageRepository.GetAllMessage());
        }
    }
}
