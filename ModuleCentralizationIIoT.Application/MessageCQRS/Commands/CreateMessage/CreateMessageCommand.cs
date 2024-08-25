using ModuleCentralizationIIoT.Application.Abstract;
using ModuleCentralizationIIoT.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModuleCentralizationIIoT.Application.MessageCQRS.Commands.CreateMessage
{
    public record  CreateMessageCommand(string text , ModuleIIoT moduleIioT) : ICommand<Message>;
}
