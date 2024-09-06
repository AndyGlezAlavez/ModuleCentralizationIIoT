#region    USINGS
using ModuleCentralizationIIoT.Domain.Entities.Types;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
#endregion

namespace ModuleCentralizationIIoT.Domain.Entities
{
    
    /// <summary>
    /// Modela un mensaje.
    /// </summary>
    public class Message :Entity
    {
        #region      PROPERTIES

        /// <summary>
        /// Texto del mensaje.
        /// </summary>
        public string Text { get; set; }

        /// <summary>
        /// Fecha y hora del mensaje
        /// </summary>
        public DateTime CreationMessage { get; set; }

        /// <summary>
        /// Prioridad del mensaje.
        /// </summary>
        public Priority Priority { get; set; }




        /// <summary>
        /// Relación del mensaje con su módulo correspondiente
        /// </summary>
        public Guid? ModuleIIoTId {  get; set; }

        /// <summary>
        /// Módulo IIoT de donde se genera el mensaje.
        /// </summary>
        public ModuleIIoT ModuleIIoT{ get; set; }

        #endregion


        #region    CONSTRUCTOR
        /// <summary>
        /// Requerido por EntityFrameworkCore para migraciones.
        /// </summary>
        protected Message() { }

        /// <summary>
        /// Inicializa una mensaje. <see cref="Message"/>
        /// </summary>
        /// <param name="id">Identificador de la entidad.</param>
        /// <param name="text">Texto del mensaje.</param>
        /// <param name="moduleIIoT">Módulo IIoT de donde se genera el mensaje.</param>
        public Message(Guid id ,string text, ModuleIIoT moduleIIoT) : base(id)
        {
            Text = text;
            ModuleIIoT = moduleIIoT;
            CreationMessage = DateTime.Now;
            Priority = Priority.Low;
        }

        #endregion

    }
}
