using ModuleCentralizationIIoT.Application.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModuleCentralizationIIoT.Application.MessageCQRS.Commands.DeleteMessage
{
    public record DeleteMessageCommand(Guid id) : ICommand;
}
