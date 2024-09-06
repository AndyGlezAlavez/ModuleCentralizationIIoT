using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModuleCentralizationIIoT.Domain.Entities
{

    /// <summary>
    /// Modela un módulo IIOT.
    /// </summary>
    public class ModuleIIoT :Entity
    {
        #region Properties

        /// <summary>
        /// Nombre del módulo.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Dirección IP del módulo.
        /// </summary>
        public string AddresIp { get; set; }

        /// <summary>
        /// Puerto de acceso del módulo.
        /// </summary>
        public string AccessPort{ get; set; }

        /// <summary>
        /// Indica si el módulo está conectado.
        /// </summary>
        public bool IsConnected { get; set; }

        /// <summary>
        /// Relación módulos-unidades
        /// </summary>
        public List<Unity> Unities { get; set; }

        /// <summary>
        /// Relación módulo-mensajes.
        /// </summary>
        public List<Message> Messages { get; set; }
        #endregion

        /// <summary>
        /// Requerido por EntityFrameworkCore para migraciones.
        /// </summary>
        protected ModuleIIoT() { }

        /// <summary>
        /// El módulo deberá tener un puerto de acceso de hasta 4 cifras.
        /// </summary>
        /// <param name="accessPort">Puerto de acceso del módulo</param>
        public void ChangesAccessPort(string accessPort)
        {
            if(accessPort.Length>=4) return;
            AccessPort = accessPort;
        }

        /// <summary>
        /// Inicializa un módulo. <see cref="ModuleIIoT"/>
        /// </summary>
        /// <param name="id">Identificador de la entidad.</param>
        /// <param name="name">Nombre del módulo.</param>
        /// <param name="addressIp">Dirección IP del módulo.</param>
        public ModuleIIoT(Guid id, string name, string addressIp) : base(id) 
        {
            Name = name;
            AddresIp = addressIp;
            IsConnected = false;
            AccessPort = "0";
        }

    }
}
