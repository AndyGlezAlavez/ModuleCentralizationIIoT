using ModuleCentralizationIIoT.Application.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModuleCentralizationIIoT.Application.UnityCQRS.Commands.DeleteUnity
{
    public record DeleteUnityCommand(Guid id) : ICommand;
}
