using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModuleCentralizationIIoT.Domain.Entities
{
    public class Unity : Entity
    {
        #region properties
        public string Name { get; set; }
        public string Code { get; set; }
        public string Area { get; set; }
        // cada unidad puede ser atendida por varios modulos
        public List<ModuleIIoT> ModuleIIoTs { get; set; }
        #endregion

        protected Unity() { }
        public Unity(Guid id,string code, string name) : base(id)
        {
            Code = code;
            Name = name;
            Area = string.Empty;
        }

    }
}
