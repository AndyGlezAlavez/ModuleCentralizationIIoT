using ModuleCentralizationIIoT.Application.Abstract;
using ModuleCentralizationIIoT.Contracts;
using ModuleCentralizationIIoT.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModuleCentralizationIIoT.Application.UnityCQRS.Queries.GetAllUnity
{
    public class GetAllUnityQueryHandler : IQueryHandler<GetAllUnityQuery, IEnumerable<Unity>>
    {
        private readonly IUnityRepository _unityRepository;
        public GetAllUnityQueryHandler(IUnityRepository unityRepository)
        {
            _unityRepository = unityRepository;
        }

        public Task<IEnumerable<Unity>> Handle(GetAllUnityQuery request, CancellationToken cancellationToken)
        {
            return Task.FromResult(_unityRepository.GetAllUnity());
        }
    }
}
