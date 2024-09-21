using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ModuleCentralizationIIoT.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModuleCentralizationIIoT.DataAccess.FluentConfigurations
{
    public class UnityEntityTypeConfiguration
    {
        public void Configure(EntityTypeBuilder<Unity> builder)
        {
            builder.ToTable("Unity");
            //builder.HasMany(x => x.ModuleIIoTs).WithMany(x => x.ModuleIIoTId);
        }
    }
}
