using ModuleCentralizationIIoT.Application.Abstract;
using ModuleCentralizationIIoT.Contracts;
using ModuleCentralizationIIoT.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModuleCentralizationIIoT.Application.ModuleCQRS.Queries.GetAllModuleIIoT
{
    public class GetAllModuleIIoTQueryHandler : IQueryHandler<GetAllModuleIIoTQuery, IEnumerable<ModuleIIoT>>
    {
        private readonly IModuleIIoTRepository _moduleIIoTRepository;

        public GetAllModuleIIoTQueryHandler(IModuleIIoTRepository moduleIIoTRepository)
        {
            _moduleIIoTRepository = moduleIIoTRepository;
        }

        public Task<IEnumerable<ModuleIIoT>> Handle(GetAllModuleIIoTQuery request, CancellationToken cancellationToken)
        {
            return Task.FromResult(_moduleIIoTRepository.GetAllModuleIIoT());
        }
    }
}
