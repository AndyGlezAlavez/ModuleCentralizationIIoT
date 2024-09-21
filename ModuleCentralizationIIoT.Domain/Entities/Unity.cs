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
        #region properties
        public string Name { get; set; }
        public string Code { get; set; }
        public string Area { get; set; }
        public List<ModuleIIoT> ModuleIIoTs { get; set; }      // Cada unidad puede ser atendida por varios modulos.
        #endregion

        protected Unity() { }                           //**********Revisar esta línea**********

        /// <summary>
        /// Inicializa una unidad. <see cref="Unity"/>
        /// </summary>
        /// <param name="code">Código alfanumérico.</param>
        /// <param name="name">Nombre.</param>
        public Unity(string code, string name)
        {
            Code = code;
            Name = name;
            Area = string.Empty;
        }

    }
}
