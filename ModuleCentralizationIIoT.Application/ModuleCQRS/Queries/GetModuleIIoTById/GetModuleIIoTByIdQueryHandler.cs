using ModuleCentralizationIIoT.Application.Abstract;
using ModuleCentralizationIIoT.Contracts;
using ModuleCentralizationIIoT.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModuleCentralizationIIoT.Application.ModuleCQRS.Queries.GetModuleIIoTById
{
    public class GetModuleIIoTByIdQueryHandler : IQueryHandler<GetModuleIIoTByIdQuery, ModuleIIoT?>
    {
        private readonly IModuleIIoTRepository _moduleIIoTRepository;

        public GetModuleIIoTByIdQueryHandler(IModuleIIoTRepository moduleIIoTRepository)
        {
            _moduleIIoTRepository = moduleIIoTRepository;
        }

        public Task<ModuleIIoT?> Handle(GetModuleIIoTByIdQuery request, CancellationToken cancellationToken)
        {
            return Task.FromResult(_moduleIIoTRepository.GetModuleIIoTById(request.id));
        }
    }
}
