using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModuleCentralizationIIoT.Domain.Entities
{
    public class ModuleIIoTAndUnity : Entity
    {
        #region Property
        public ModuleIIoT ModuleIIoTd { get; set; }
        public Unity UnityId { get; set; }
        #endregion
        protected ModuleIIoTAndUnity() { }
    }
}
