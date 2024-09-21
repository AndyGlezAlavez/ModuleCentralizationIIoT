using ModuleCentralizationIIoT.Domain.Entities.Types;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModuleCentralizationIIoT.Domain.Entities
{
    /// <summary>
    /// Modela un mensaje.
    /// </summary>
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

        /// <summary>
        /// Inicializa una mensaje. <see cref="Message"/>
        /// </summary>
        /// <param name="text">Texto del mensaje.</param>
        /// <param name="creationMessage">Fecha de creación.</param>
        /// <param name="moduleIIoT">Módulo IIOT correspondiente.</param>
        public Message(string text, DateTime creationMessage, ModuleIIoT moduleIIoT)
        {
            Text = text;
            ModuleIIoT = moduleIIoT;
            CreationMessage = creationMessage;                                                  //*********Revisar. Poner tipo de dato correspondiente**********
        }
    }
}
