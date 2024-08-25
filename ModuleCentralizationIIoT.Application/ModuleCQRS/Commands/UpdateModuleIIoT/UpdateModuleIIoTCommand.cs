using ModuleCentralizationIIoT.Application.Abstract;
using ModuleCentralizationIIoT.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModuleCentralizationIIoT.Application.ModuleCQRS.Commands.UpdateModuleIIoT
{
    public record UpdateModuleIIoTCommand(ModuleIIoT moduleIIoT) : ICommand;
}
