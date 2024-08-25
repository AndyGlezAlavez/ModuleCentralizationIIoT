using ModuleCentralizationIIoT.Application.Abstract;
using ModuleCentralizationIIoT.Contracts;
using ModuleCentralizationIIoT.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModuleCentralizationIIoT.Application.UnityCQRS.Queries.GetUnityById
{
    public class GetUnityByIdQueryHandler : IQueryHandler<GetUnityByIdQuery, Unity?>
    {
        private readonly IUnityRepository _unityRepository;

        public GetUnityByIdQueryHandler(IUnityRepository unityRepository)
        {
            _unityRepository = unityRepository;

        }

        public Task<Unity?> Handle(GetUnityByIdQuery request, CancellationToken cancellationToken)
        {
            return Task.FromResult(_unityRepository.GetUnityById(request.id));
        }
    }
}
