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
    public class MessageEntityTypeConfiguration : EntityTypeConfigurationBase<Message>
    {
        public void Configure(EntityTypeBuilder<Message> builder)
        { 
            builder.ToTable("Message");
            builder.HasOne(x => x.ModuleIIoT).WithMany().HasForeignKey(x=>x.ModuleIIoTId);
        }
    }
}
