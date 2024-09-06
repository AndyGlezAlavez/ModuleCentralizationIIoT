#region   USINGS
using Microsoft.EntityFrameworkCore;
using ModuleCentralizationIIoT.DataAccess.FluentConfigurations;
using ModuleCentralizationIIoT.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
#endregion

namespace ModuleCentralizationIIoT.DataAccess.Contexts
{
    public class ApplicationContext: DbContext
    {
        // Declarando las tablas de las entidades Base
        #region TABLES
        public DbSet<ModuleIIoT> ModuleIIoTs { get; set; }        
        public DbSet<Unity> Unities { get; set; }
        public DbSet<Message> Messages { get; set; }
        #endregion


        //Obteniendo Opciones del Contexto
        #region HELPERS
        private static DbContextOptions GetOptions(string connectionString)
        {
            return SqliteDbContextOptionsBuilderExtensions.UseSqlite(
                new DbContextOptionsBuilder(), connectionString).Options;
        }
        #endregion


        #region   CONSTRUCTOR
        public ApplicationContext() { }

        public ApplicationContext(string conectionString)
          : base(GetOptions(conectionString))
        {
        }

        public ApplicationContext(DbContextOptions<ApplicationContext> options) :
            base(options)
        {
        }





        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlite();
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new MessageEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new UnityEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new ModuleIIoTEntittyTypeConfiguration());

        }
        #endregion
    }
}
