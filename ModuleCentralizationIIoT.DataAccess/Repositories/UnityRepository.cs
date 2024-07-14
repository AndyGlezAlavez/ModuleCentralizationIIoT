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
    public class UnityRepository : RepositoryBase, IUnityRepository
    {
        public UnityRepository(ApplicationContext context) : base(context)
        {
        }

        public void AddUnity(Unity unity)
        {
            _context.Unities.Add(unity);
        }

        public void DeleteUnity(Unity unity)
        {
            _context.Unities.Remove(unity);
        }

        public IEnumerable<Unity> GetAllUnity()
        {
            return _context.Unities.ToList();
        }

        public Unity? GetUnityById(Guid id)
        {
            return _context.Unities.FirstOrDefault(u => u.Id == id);
        }

        public void UpdateUnity(Unity unity)
        {
            _context.Unities.Update(unity);
        }
    }
}
