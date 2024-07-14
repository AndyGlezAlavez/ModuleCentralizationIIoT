using ModuleCentralizationIIoT.Contracts;
using ModuleCentralizationIIoT.DataAccess.Contexts;
using ModuleCentralizationIIoT.DataAccess.Repositories.Common;
using ModuleCentralizationIIoT.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModuleCentralizationIIoT.DataAccess.Repositories
{
    internal class ModuleIIoTRepository : RepositoryBase, IModuleIIoTRepository
    {
        public ModuleIIoTRepository(ApplicationContext context) : base(context)
        {
        }

        public void AddModuleIIoT(ModuleIIoT moduleIIoT)
        {
            _context.ModuleIIoTs.Add(moduleIIoT);
        }

        public void DeleteModuleIIoT(ModuleIIoT moduleIIoT)
        {
            _context.ModuleIIoTs.Remove(moduleIIoT);
        }

        public IEnumerable<ModuleIIoT> GetAllModuleIIoT()
        {
            return _context.ModuleIIoTs.ToList();
        }

        public ModuleIIoT? GetModuleIIoTById(Guid id)
        {
            return _context?.ModuleIIoTs.FirstOrDefault(t => t.Id == id);
        }

        public void UpdateModuleIIoT(ModuleIIoT moduleIIoT)
        {
             _context.ModuleIIoTs.Update(moduleIIoT);
        }
    }
}
