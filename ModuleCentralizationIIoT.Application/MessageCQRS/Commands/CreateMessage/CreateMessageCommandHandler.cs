using ModuleCentralizationIIoT.Application.Abstract;
using ModuleCentralizationIIoT.Contracts;
using ModuleCentralizationIIoT.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModuleCentralizationIIoT.Application.MessageCQRS.Commands.CreateMessage
{
    public class CreateMessageCommandHandler : ICommandHandler<CreateMessageCommand, Message>
    {
        private readonly IMessageRepository _messageRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IModuleIIoTRepository _moduleIIoTrepository;
        
        public CreateMessageCommandHandler(IMessageRepository messageRepository, IUnitOfWork unitOfWork,IModuleIIoTRepository moduleIIoTRepository)
        {
            _messageRepository = messageRepository;
            _unitOfWork = unitOfWork;
            _moduleIIoTrepository = moduleIIoTRepository;
            
        }

        public Task<Message> Handle(CreateMessageCommand request, CancellationToken cancellationToken)
        {
            var module = _moduleIIoTrepository.GetModuleIIoTById(request.moduleIioT.Id);
            Message result= new Message(
                Guid.NewGuid(),
                request.text,
               module);
            _messageRepository.AdddMessage(result);
            _unitOfWork.SaveChages();
           return Task.FromResult(result);

        }
    }
}
