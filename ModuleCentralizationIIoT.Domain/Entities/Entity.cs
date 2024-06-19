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
        //1 2 3 flechita ingles
        ///identificador en el soporte de datos
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id {  get; set; }

    }
}
