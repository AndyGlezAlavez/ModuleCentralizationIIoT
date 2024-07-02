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
        public string Text { get; set; }
        public DateTime CreationMessage { get; set; }
        public Priority Priority { get; set; }
        //relacion con su modulo correspondiente
        public Guid ModuleIIoTId {  get; set; }
        public ModuleIIoT ModuleIIoT{ get; set; }
        #endregion

        protected Message() { }

        public Message(string text, DateTime creationMessage, ModuleIIoT moduleIIoT)
        {
            Text = text;
            ModuleIIoT = moduleIIoT;
            CreationMessage = creationMessage;
        }
    }
}
