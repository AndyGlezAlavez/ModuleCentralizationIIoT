
using Microsoft.EntityFrameworkCore;
using ModuleCentralizationIIoT.DataAccess.FluentConfigurations;
using ModuleCentralizationIIoT.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModuleCentralizationIIoT.DataAccess.Contexts
{
    public class ApplicationContext: DbContext
    {
        #region Tables
        public DbSet<ModuleIIoT> ModuleIIoTs { get; set; }
        public DbSet<Unity> Unities { get; set; }
        public DbSet<Message> Messages { get; set; }
        #endregion
        public ApplicationContext() { }

        public ApplicationContext(string connectionString): base(GetOptions(connectionString)) { }

        public ApplicationContext(DbContextOptions options) : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlite();
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            #region Mapping
  
            modelBuilder.Entity<ModuleIIoT>().ToTable("ModuleIIoT");
            modelBuilder.Entity<Unity>().ToTable("Unity");
            modelBuilder.Entity<Message>().ToTable("Message");
            #endregion

            modelBuilder.ApplyConfiguration(new MessageEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new UnityEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new ModuleIIoTEntittyTypeConfiguration());

        }


        private static DbContextOptions GetOptions(string connectionString)
        {
            return SqliteDbContextOptionsBuilderExtensions.UseSqlite(new DbContextOptionsBuilder(), connectionString).Options;
        }

    }
}
