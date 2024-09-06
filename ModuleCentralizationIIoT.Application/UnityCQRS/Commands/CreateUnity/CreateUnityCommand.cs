#region    USINGS
using ModuleCentralizationIIoT.Application.Abstract;
using ModuleCentralizationIIoT.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
#endregion

namespace ModuleCentralizationIIoT.Application.UnityCQRS.Commands.CreateUnity
{
    public record CreateUnityCommand(string name ,string code) : ICommand<Unity>;
}
