using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModuleCentralizationIIoT.Domain.Entities
{
    public class Unities : Entity
    {
        #region properties
        public int IdUnities {  get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public string Area { get; set; }
        // cada unidad puede ser atendida por varios modulos
        [NotMapped]
        public ModuleIIoT ModuleIIoT { get; set; }
        #endregion

        public Unities(string code, string name) 
        {
            Code = code;
            Name = name;
            Area= string.Empty;
        }
    }
}
