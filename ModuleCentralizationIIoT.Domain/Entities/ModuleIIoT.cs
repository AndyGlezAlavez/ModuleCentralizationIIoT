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
        #region
        public string Name { get; set; }
        public string AddresIp { get; set; }
        public string AccessPort
        {
            get {  return AccessPort; }
            set
            {
                if (value.Length > 4)
                {
                    AccessPort = null;
                }
                AccessPort = value;
            } 
        }
  
 
        public bool IsConnected { get; set; }


        public List<Unity> Unities { get; set; }

        public List<Message> Messages { get; set; }
        #endregion

        protected ModuleIIoT() { }

        /// <summary>
        /// Inicializa un módulo. <see cref="ModuleIIoT"/>
        /// </summary>
        /// <param name="name">Nombre.</param>
        /// <param name="addressIp">Dirección IP</param>
        public ModuleIIoT(string name, string addressIp) 
        {
            Name = name;
            AddresIp = addressIp;
            IsConnected = false;
        }

    }
}
