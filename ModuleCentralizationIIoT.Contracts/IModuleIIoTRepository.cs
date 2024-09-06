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
    public interface IModuleIIoTRepository
    {
        void AddModuleIIoT(ModuleIIoT moduleIIoT);
        ModuleIIoT? GetModuleIIoTById(Guid id);
        public IEnumerable<ModuleIIoT> GetAllModuleIIoT();
        void UpdateModuleIIoT(ModuleIIoT moduleIIoT);
        void DeleteModuleIIoT(ModuleIIoT moduleIIoT);

        public IEnumerable<Message> GetMessageByModuleIIoT(Guid moduleId);

    }
}
