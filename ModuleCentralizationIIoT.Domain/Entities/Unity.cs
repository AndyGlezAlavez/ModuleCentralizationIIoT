using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModuleCentralizationIIoT.Domain.Entities
{

    /// <summary>
    /// Modela una unidad.
    /// </summary>
    public class Unity : Entity
    {
        #region Properties

        /// <summary>
        /// Nombre de la unidad.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Código alfanumérico de la unidad.
        /// </summary>
        public string Code { get; set; }

        /// <summary>
        /// Área donde se encuentra localizada la unidad.
        /// </summary>
        public string Area { get; set; }

        /// Cada unidad puede ser atendida por varios módulos
        public List<ModuleIIoT> ModuleIIoTs { get; set; }
        #endregion

        ///<summary>
        /// Requerido por EntityFrameworkCore para migraciones.
        /// </summary>
        protected Unity() { }

        /// <summary>
        /// Inicializa una unidad. <see cref="Unity"/>
        /// </summary>
        /// <param name="id">Identificador de la entidad.</param>
        /// <param name="code">Código alfanumérico de la unidad.</param>
        /// <param name="name">Nombre de la unidad.</param>
        public Unity(Guid id,string code, string name) : base(id) 
        {
            Code = code;
            Name = name;
            Area = string.Empty;
        }

    }
}
