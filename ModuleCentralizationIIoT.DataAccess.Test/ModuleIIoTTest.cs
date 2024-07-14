using ModuleCentralizationIIoT.Contracts;
using ModuleCentralizationIIoT.DataAccess.Contexts;
using ModuleCentralizationIIoT.DataAccess.Repositories;
using ModuleCentralizationIIoT.DataAccess.Test.Utilities;
using ModuleCentralizationIIoT.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModuleCentralizationIIoT.DataAccess.Test
{
    public class ModuleIIoTTest
    {
        private IModuleIIoTRepository _moduleIIoTRepository;
        private IUnitOfWork _unitOfWork;
        public ModuleIIoTTest()
        {
            ApplicationContext context = new ApplicationContext(ConnectionStringProvider.GetConnectionString());
            _moduleIIoTRepository = new ModuleIIoTRepository(context);
            _unitOfWork = new UnitOfWork(context);
        }
        [DataRow("Modulo ZigBee", "192.168.140.0")]
        [DataRow("Modulo LTE", "255.255.255.5")]

        [TestMethod]

        public void Can_Add_ModuleIIoT(
            string name,
            string addressIp)
        {
            //Arrange
            Guid id = Guid.NewGuid();
            ModuleIIoT moduleIIoT = new ModuleIIoT(name, addressIp);
            moduleIIoT.Id = id;

            //Execute
            _moduleIIoTRepository.AddModuleIIoT(moduleIIoT);
            _unitOfWork.SaveChages();

            //Assert
            ModuleIIoT? loadedModuleIIoT = _moduleIIoTRepository.GetModuleIIoTById(id);
            Assert.IsNotNull(loadedModuleIIoT);
        }

        [DataRow(0)]
        [TestMethod]

        public void Can_Get_ModuleIIoT_By_Id(int position)
        {
            //Arrange
            var moduleIIoT= _moduleIIoTRepository.GetAllModuleIIoT().ToList();
            Assert.IsNotNull(moduleIIoT);
            Assert.IsTrue(position < moduleIIoT.Count);
            ModuleIIoT moduleIIoTToGet = moduleIIoT[position];

            //Execute
            ModuleIIoT? loadedModuleIIoT= _moduleIIoTRepository.GetModuleIIoTById(moduleIIoTToGet.Id);

            //Assert
            Assert.IsNotNull(loadedModuleIIoT);

        }
        public void Cannot_Get_ModuleIIoT_By_Invalid_Id()
        {
            //Arrange

            //Execute
            ModuleIIoT? loadedModuleIIoT= _moduleIIoTRepository.GetModuleIIoTById(Guid.Empty);

            //Assert
            Assert.IsNotNull(loadedModuleIIoT);
        }/*        [DataRow(0)]
        [TestMethod]

        public void Can_Delete_ModuleIIoT(int position) 
        {
            //Arrange
            var ModuleIIoT= _moduleIIoTRepository.GetAllModuleIIoT();
            Assert.IsNotNull(ModuleIIoT);
            var count=ModuleIIoT.Count();
            var moduleIIoTs= moduleIIoTs.ElementAt(position);
            Assert.IsNotNull(moduleIIoTs);

            //Execute
            _moduleIIoTRepository.DeleteModuleIIoT(moduleIIoTs);
            _unitOfWork.SaveChages();

            //Assert
            ModuleIIoTs _moduleIIoTRepository.GetAllModuleIIoT();
            Assert.AreEqual(count-1, moduleIIoTs.Count());
            var DeletemoduleIIoT = _moduleIIoTRepository.GetModuleIIoTById(moduleIIoTs.Id);*/
        }

    }
}
