using ModuleCentralizationIIoT.Application.Abstract;
using ModuleCentralizationIIoT.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModuleCentralizationIIoT.Application.UnityCQRS.Commands.UpdateUnity
{
    public class UpdateUnityCommandHandler : ICommandHandler<UpdateUnityCommand>
    {
        private readonly IUnityRepository _unityRepository;
        private readonly IUnitOfWork _unitOfWork;

        public UpdateUnityCommandHandler(IUnityRepository unityRepository, IUnitOfWork unitOfWork)
        {
            _unityRepository = unityRepository;
            _unitOfWork = unitOfWork;
        }

        public Task Handle(UpdateUnityCommand request, CancellationToken cancellationToken)
        {
            _unityRepository.UpdateUnity(request.unity);
            _unitOfWork.SaveChages();
            return Task.CompletedTask;
        }
    }
}
