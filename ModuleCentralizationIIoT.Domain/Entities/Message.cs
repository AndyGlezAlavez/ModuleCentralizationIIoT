using ModuleCentralizationIIoT.Domain.Entities.Types;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModuleCentralizationIIoT.Domain.Entities
{
    public class Message :Entity
    {
        #region Prorperties
        public int IdMessage {  get; set; }
        public string Text { get; set; }
        public DateTime CreationMessage { get; set; }
        public Priority Priority { get; set; }
        //relacion con su modulo correspondiente
        [NotMapped]
        public ModuleIIoT Module { get; set; }
        public int IdModuleIIoT { get; set; }
        #endregion

        public Message(string text, DateTime creationMessage, ModuleIIoT module)
        {
            Text = text;
            Module = module;
            CreationMessage = creationMessage;
        }
    }
}
