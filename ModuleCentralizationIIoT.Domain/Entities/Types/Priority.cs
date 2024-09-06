#region      USINGS
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
#endregion

namespace ModuleCentralizationIIoT.Domain.Entities.Types
{ 
    
    /// <summary>
    /// Prioridad de un mensaje.
    /// </summary>
    public enum Priority
    {
        /// <summary>
        /// Baja
        /// </summary>
        Low, 

        /// <summary>
        /// Media
        /// </summary>
        Medium,

        /// <summary>
        /// Alta
        /// </summary>
        High,
    }
}
