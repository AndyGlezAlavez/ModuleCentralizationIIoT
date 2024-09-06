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

namespace ModuleCentralizationIIoT.Application.UnityCQRS.Commands.CreateUnity
{
    public class CreateUnityCommandHandler : ICommandHandler<CreateUnityCommand, Unity>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IUnityRepository _unityrepository;

        public CreateUnityCommandHandler(IUnitOfWork unitOfWork, IUnityRepository unityrepository)
        {
            _unitOfWork = unitOfWork;
            _unityrepository = unityrepository;
        }

        public Task<Unity> Handle(CreateUnityCommand request, CancellationToken cancellationToken)
        {
            Unity result = new Unity(
                Guid.NewGuid(),
                request.code,
                request.name);

            _unityrepository.AddUnity(result);
            _unitOfWork.SaveChages();
             
            return Task.FromResult(result);
            
        }
    }
}
