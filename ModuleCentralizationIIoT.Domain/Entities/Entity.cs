#region    USINGS
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;//new
using System.ComponentModel.DataAnnotations.Schema;//nes
using System.Linq;
using System.Text;
using System.Threading.Tasks;
#endregion

namespace ModuleCentralizationIIoT.Domain.Entities
{

    /// <summary>
    /// Clase base para todas las entidades en el soporte de datos.
    /// </summary>
    public abstract class Entity
    {
        #region    PROPERTIES

        /// <summary>
        /// Identificador en el soporte de datos.
        /// </summary>
        public Guid Id {  get; set; }

        #endregion


        #region    CONSTRUCTOR

        /// <summary>
        /// Requerido por EntityFramework.
        /// </summary>
        protected Entity() { }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id">Identificador de la entidad.</param>
        protected Entity(Guid id) {  Id = id; }

        #endregion
    }
}
