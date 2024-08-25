using ModuleCentralizationIIoT.Application.Abstract;
using ModuleCentralizationIIoT.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModuleCentralizationIIoT.Application.ModuleCQRS.Queries.GetModuleIIoTById
{
    public record GetModuleIIoTByIdQuery(Guid id) : IQuery<ModuleIIoT?>;
}
