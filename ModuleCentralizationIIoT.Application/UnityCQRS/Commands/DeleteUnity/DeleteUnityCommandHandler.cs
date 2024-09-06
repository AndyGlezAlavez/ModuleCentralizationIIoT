#region    USINGS
using ModuleCentralizationIIoT.Application.Abstract;
using ModuleCentralizationIIoT.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
#endregion

namespace ModuleCentralizationIIoT.Application.UnityCQRS.Commands.DeleteUnity
{
    public class DeleteUnityCommandHandler : ICommandHandler<DeleteUnityCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IUnityRepository _unityrepository;

        public DeleteUnityCommandHandler(IUnitOfWork unitOfWork, IUnityRepository unityrepository)
        {
            _unitOfWork = unitOfWork;
            _unityrepository = unityrepository;
        }

        public Task Handle(DeleteUnityCommand request, CancellationToken cancellationToken)
        {
            var UnityToDelete = _unityrepository.GetUnityById(request.id);
            if (UnityToDelete == null)
            {
                return Task.CompletedTask;
            }
            _unityrepository.DeleteUnity(UnityToDelete);
            _unitOfWork.SaveChages();
            return Task.CompletedTask;
        }
    }
}
