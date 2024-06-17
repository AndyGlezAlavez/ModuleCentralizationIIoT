using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModuleCentralizationIIoT.Domain.Entities
{
    public class ModuleIIoT
    {
        #region
        public string Name { get; set; }
        public string AddresIp { get; set; }
        public string AccessPort { get; set; }
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
