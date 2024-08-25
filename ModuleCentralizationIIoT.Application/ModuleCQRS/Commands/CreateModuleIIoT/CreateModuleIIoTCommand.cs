using ModuleCentralizationIIoT.Application.Abstract;
using ModuleCentralizationIIoT.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModuleCentralizationIIoT.Application.ModuleCQRS.Commands.CreateModuleIIoT
{
    public record CreateModuleIIoTCommand(string name , string addressIp) : ICommand<ModuleIIoT>;
}
