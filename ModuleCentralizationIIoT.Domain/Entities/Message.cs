using ModuleCentralizationIIoT.Domain.Entities.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModuleCentralizationIIoT.Domain.Entities
{
    public class Message
    {
        #region Prorperties
        public string Text { get; set; }
        public DateTime CreationMessage { get; set; }
        public Priority Priority { get; set; }
        #endregion
        public ModuleIIoT Module {  get; set; }
        public Message(string text, DateTime creationMessage, ModuleIIoT module)
        {
            Text = text;
            Module = module;
            CreationMessage = creationMessage;
        }
    }
}
