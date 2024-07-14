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
        public void Configure(EntityTypeBuilder<ModuleIIoT> builder)
        {
            builder.ToTable("ModuleIIoT");
            // builder.HasMany(x => x.Unities).WithMany().UsingEntity(j => j.Totable("ModuleIIoT"));
           // builder.HasOne(x => x.Unities).WithMany().HasForeignKey(x => x.UnityId);
        }
    }
}
