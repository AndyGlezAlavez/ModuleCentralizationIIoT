using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModuleCentralizationIIoT.Domain.Entities
{
    public class ModuleIIoT :Entity
    {
        #region
        public int IdModuleIIoT { get; set; }
        public string Name { get; set; }
        public string AddresIp { get; set; }
        public string AccessPort
        {
            get {  return AccessPort; }
            set
            {

            } 
        }//puerto de acceso de 4 cifras
        // modulo tiene varias unidades
        [NotMapped]
        public List<Unities> Unities { get; set; }
        //cada modulo puede tener varios mensajes
        [NotMapped]
        public List<Message> Message { get; set; }
        public bool IsConnected { get; set; }

        #endregion
        public ModuleIIoT(string name, string addessIp) 
        {
            Name = name;
            AddresIp = addessIp;
            IsConnected = false;
        }

    }
}
