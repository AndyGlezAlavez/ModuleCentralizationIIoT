using ModuleCentralizationIIoT.Application.Abstract;
using ModuleCentralizationIIoT.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModuleCentralizationIIoT.Application.MessageCQRS.Commands.UpdateMessage
{
    public class UpdateMessageCommandHandler : ICommandHandler<UpdateMessageCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMessageRepository _messageRepository;

        public UpdateMessageCommandHandler(IUnitOfWork unitOfWork, IMessageRepository messageRepository)
        {
            _unitOfWork = unitOfWork;
            _messageRepository = messageRepository;
        }

        public Task Handle(UpdateMessageCommand request, CancellationToken cancellationToken)
        {
            _messageRepository.UpdateMessage(request.message);
            _unitOfWork.SaveChages();
            return Task.CompletedTask;
        }
    }
}
