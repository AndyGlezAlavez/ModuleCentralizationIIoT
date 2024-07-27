using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ModuleCentralizationIIoT.DataAccess.FluentConfigurations.Common;
using ModuleCentralizationIIoT.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModuleCentralizationIIoT.DataAccess.FluentConfigurations
{
    public class UnityEntityTypeConfiguration : EntityTypeConfigurationBase<Unity>
    {
        public override void Configure(EntityTypeBuilder<Unity> builder)
        {
            builder.ToTable("Unity");
            base.Configure(builder);
        }
    }
}
