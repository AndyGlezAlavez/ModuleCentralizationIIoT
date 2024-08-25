using ModuleCentralizationIIoT.Application.Abstract;
using ModuleCentralizationIIoT.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModuleCentralizationIIoT.Application.MessageCQRS.Commands.DeleteMessage
{
    public class DeleteMessageCommandHandler : ICommandHandler<DeleteMessageCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMessageRepository _messageRepository;

        public DeleteMessageCommandHandler(IUnitOfWork unitOfWork, IMessageRepository messageRepository)
        {
            _unitOfWork = unitOfWork;
            _messageRepository = messageRepository;
        }

        public Task Handle(DeleteMessageCommand request, CancellationToken cancellationToken)
        {
            var MessageToDelete = _messageRepository.GetMessageById(request.id);
            if (MessageToDelete == null) 
                return Task.CompletedTask;

            _messageRepository.DeleteMessage(MessageToDelete);
            _unitOfWork.SaveChages();
            return Task.CompletedTask;
        }
    }
}
