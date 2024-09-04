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
        public string Name { get; set; }
        public string AddresIp { get; set; }
        public string AccessPort{ get; set; }


        public bool IsConnected { get; set; }


        public List<Unity> Unities { get; set; }

        public List<Message> Messages { get; set; }
        #endregion

        protected ModuleIIoT() { }

        public void ChangesAccessPort(string accessPort)
        {
            if(accessPort.Length==4) return;
            AccessPort = accessPort;
        }

        public ModuleIIoT(Guid id, string name, string addressIp) : base(id) 
        {
            Name = name;
            AddresIp = addressIp;
            IsConnected = false;
            AccessPort = "0";

        }

    }
}
