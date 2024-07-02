using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;//new
using System.ComponentModel.DataAnnotations.Schema;//nes
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModuleCentralizationIIoT.Domain.Entities
{
    public abstract class Entity
    {
        ///identificador en el soporte de datos

        public Guid Id {  get; set; }

    }
}
