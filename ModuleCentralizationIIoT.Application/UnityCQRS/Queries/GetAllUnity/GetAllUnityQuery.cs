#region    USINGS
using ModuleCentralizationIIoT.Application.Abstract;
using ModuleCentralizationIIoT.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
#endregion

namespace ModuleCentralizationIIoT.Application.UnityCQRS.Queries.GetAllUnity
{
    public record GetAllUnityQuery : IQuery<IEnumerable<Unity>>;
}
