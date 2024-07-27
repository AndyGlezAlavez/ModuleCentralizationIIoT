using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ModuleCentralizationIIoT.DataAccess.FluentConfigurations.Common;
using ModuleCentralizationIIoT.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace ModuleCentralizationIIoT.DataAccess.FluentConfigurations
{
    public class ModuleIIoTEntittyTypeConfiguration : EntityTypeConfigurationBase<ModuleIIoT>
    {
        public override void Configure(EntityTypeBuilder<ModuleIIoT> builder)
        {
            builder.ToTable("ModuleIIoT");
            base.Configure(builder);
            builder.HasMany(x => x.Unities).WithMany(x =>x.ModuleIIoTs);
        }
    }
}
