using Microsoft.EntityFrameworkCore;
using ModuleCentralizationIIoT.Contracts;
using ModuleCentralizationIIoT.DataAccess.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModuleCentralizationIIoT.DataAccess
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationContext _context;
        public UnitOfWork(ApplicationContext context)
        {
            _context = context;
            if(context.Database.CanConnect())
                context.Database.Migrate();
        }

        public void SaveChages()
        {
            _context.SaveChanges();
        }
    }
}
