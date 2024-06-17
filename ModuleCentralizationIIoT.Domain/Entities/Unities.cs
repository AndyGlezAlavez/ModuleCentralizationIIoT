using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModuleCentralizationIIoT.Domain.Entities
{
    public class Unities
    {
        #region properties
        public string Name { get; set; }
        public string Code { get; set; }
        public string Area { get; set; }

        #endregion

        public Unities(string code, string name) 
        {
            Code = code;
            Name = name;
            Area= string.Empty;
        }
    }
}
