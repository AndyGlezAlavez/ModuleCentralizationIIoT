#region    USINGS
using ModuleCentralizationIIoT.Application.Abstract;
using ModuleCentralizationIIoT.Contracts;
using ModuleCentralizationIIoT.DataAccess;
using ModuleCentralizationIIoT.DataAccess.Repositories;
using ModuleCentralizationIIoT.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
#endregion

namespace ModuleCentralizationIIoT.Application.ModuleCQRS.Commands.CreateModuleIIoT
{
    public class CreateModuleIIoTCommandHandler : ICommandHandler<CreateModuleIIoTCommand, ModuleIIoT>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IModuleIIoTRepository _moduleIIoTRepository;

        public CreateModuleIIoTCommandHandler(IUnitOfWork unitOfWork, IModuleIIoTRepository moduleIIoTRepository)
        {
            _unitOfWork = unitOfWork;
            _moduleIIoTRepository = moduleIIoTRepository;
        }

        public Task<ModuleIIoT> Handle(CreateModuleIIoTCommand request, CancellationToken cancellationToken)
        {
            ModuleIIoT result = new ModuleIIoT(
                Guid.NewGuid(),
                request.name,
                request.addressIp);
            
            _moduleIIoTRepository.AddModuleIIoT(result);
            _unitOfWork.SaveChages();
            
            return Task.FromResult(result);
        }
        
    }
}
