using ModuleCentralizationIIoT.Application.Abstract;
using ModuleCentralizationIIoT.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModuleCentralizationIIoT.Application.UnityCQRS.Queries.GetUnityById
{
    public record GetUnityByIdQuery(Guid id) : IQuery<Unity?>;

}
