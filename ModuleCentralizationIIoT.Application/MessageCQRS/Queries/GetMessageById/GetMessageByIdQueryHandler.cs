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

namespace ModuleCentralizationIIoT.Application.MessageCQRS.Queries.GetMessageById
{
    public class GetMessageByIdQueryHandler : IQueryHandler<GetMessageByIdQuery, Message?>
    {
        private readonly IMessageRepository _messageRepository;
        public GetMessageByIdQueryHandler(IMessageRepository messageRepository) 
        {
            _messageRepository = messageRepository;
        }
        public Task<Message?> Handle(GetMessageByIdQuery request, CancellationToken cancellationToken)
        {
            return Task.FromResult(_messageRepository.GetMessageById(request.id));
        }
    }
}
