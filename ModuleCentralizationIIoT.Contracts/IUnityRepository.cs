#region   USINGS
using ModuleCentralizationIIoT.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
#endregion


namespace ModuleCentralizationIIoT.Contracts
{
    public interface IUnityRepository
    {
        void AddUnity(Unity unity);
        Unity? GetUnityById(Guid id);
        public IEnumerable<Unity> GetAllUnity();
        void UpdateUnity (Unity unity);
        void DeleteUnity(Unity unity);
    }
}
