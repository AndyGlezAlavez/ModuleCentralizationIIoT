using ModuleCentralizationIIoT.Application.Abstract;
using ModuleCentralizationIIoT.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModuleCentralizationIIoT.Application.ModuleCQRS.Commands.UpdateModuleIIoT
{
    public class UpdateModuleIIoTCommandHandler : ICommandHandler<UpdateModuleIIoTCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IModuleIIoTRepository _moduleIIoTRepository;

        public UpdateModuleIIoTCommandHandler(IUnitOfWork unitOfWork, IModuleIIoTRepository moduleIIoTRepository)
        {
            _unitOfWork = unitOfWork;
            _moduleIIoTRepository = moduleIIoTRepository;
        }

        public Task Handle(UpdateModuleIIoTCommand request, CancellationToken cancellationToken)
        {
            _moduleIIoTRepository.UpdateModuleIIoT(request.moduleIIoT);
            _unitOfWork.SaveChages();
            return Task.CompletedTask;
        }
    }
}
