#region   USINGS
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ModuleCentralizationIIoT.DataAccess.FluentConfigurations.Common;
using ModuleCentralizationIIoT.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
#endregion

namespace ModuleCentralizationIIoT.DataAccess.FluentConfigurations
{
    public class MessageEntityTypeConfiguration : EntityTypeConfigurationBase<Message>
    {
        public override void Configure(EntityTypeBuilder<Message> builder)
        { 
            builder.ToTable("Message");
            base.Configure(builder);
            builder.HasOne(x => x.ModuleIIoT).WithMany(x => x.Messages).HasForeignKey(x=>x.ModuleIIoTId);

        }
    }
}
