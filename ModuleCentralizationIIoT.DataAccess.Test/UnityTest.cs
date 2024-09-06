#region     USINGS
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
#endregion

namespace ModuleCentralizationIIoT.DataAccess.Test
{

    #region  TEST   CLASS

    [TestClass]
    public class UnityTest
    {
        private IUnityRepository _unityRepository;
        private IUnitOfWork _unityOfWork;
        public UnityTest()
        {
            ApplicationContext context = new ApplicationContext(ConnectionStringProvider.GetConnectionString());
            _unityRepository = new UnityRepository(context);
            _unityOfWork = new UnitOfWork(context);
        }
        [DataRow("abc123", "Camara 1")]
        [DataRow("a1b2c3", "Camara 2")]

        #endregion

        #region   TEST  METHOD

        #region   ADD

        [TestMethod]
        public void Can_Add_Unity(
            string code,
            string name)
        {
            //Arrange
            Guid id = Guid.NewGuid();
            Unity unity = new Unity(id, code, name);
            unity.Id = id;

            //Execute
            _unityRepository.AddUnity(unity);
            _unityOfWork.SaveChages();

            //Assert
            Unity? loadedunity = _unityRepository.GetUnityById(id);
            Assert.IsNotNull(loadedunity);

        }
        [DataRow(0)]
        #endregion

        #region     GET

        [TestMethod]
        public void Can_Get_Unity_By_Id(int position)
        {
            //Arrange
            var unity = _unityRepository.GetAllUnity().ToList();
            Assert.IsNotNull(unity);
            Assert.IsTrue(position < unity.Count);
            Unity unityToGet = unity[position];

            //Execute
            Unity? loadedUnity = _unityRepository.GetUnityById(unityToGet.Id);
            //Assert
            Assert.IsNotNull(loadedUnity);

        }
        #endregion

        #region  CANNOT  GET

        [TestMethod]
        public void Cannot_Get_Unity_By_Invalid_Id()
        {
            //Arrange

            //Execute
            Unity? loadedUnity = _unityRepository.GetUnityById(Guid.Empty);

            //Assert
            Assert.IsNull(loadedUnity);

        }

        [DataRow(0)]

        #endregion

        #region   DELETE

        [TestMethod]
        public void Can_Delete_Unity(int position)
        {
            //Arrange
            var unitys = _unityRepository.GetAllUnity();
            Assert.IsNotNull(unitys);
            var count = unitys.Count();
            var unity = unitys.ElementAt(position);
            Assert.IsNotNull(unity);

            //Execute
            _unityRepository.DeleteUnity(unity);
            _unityOfWork.SaveChages();

            //Asert
            unitys = _unityRepository.GetAllUnity();
            Assert.AreEqual(count - 1, unitys.Count());
            var DeleteUnity = _unityRepository.GetUnityById(unity.Id);
            Assert.IsNull(DeleteUnity);


        }
        [DataRow(0)]

        #endregion

        #region   UPDATE

        [TestMethod]
        public void Can_Update_Unity(int position)
        {
            //Arrange
            var Unitys = _unityRepository.GetAllUnity();
            Assert.IsNotNull(Unitys);
            var unity = Unitys.ElementAt(position);
            Assert.IsNotNull(unity);

            //Execute
            unity.Name = "prueba";
            _unityRepository.UpdateUnity(unity);
            _unityOfWork.SaveChages();

            //Asert
            var updateUnity = _unityRepository.GetUnityById(unity.Id);
            Assert.IsNotNull(updateUnity);
            Assert.AreEqual(updateUnity.Name, unity.Name);
        }



    }
    #endregion


         #endregion
}
