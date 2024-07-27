using ModuleCentralizationIIoT.Contracts;
using ModuleCentralizationIIoT.DataAccess;
using ModuleCentralizationIIoT.DataAccess.Contexts;
using ModuleCentralizationIIoT.DataAccess.Repositories;
using ModuleCentralizationIIoT.DataAccess.Test.Utilities;
using ModuleCentralizationIIoT.Domain.Entities;

namespace ModuleCentralization_IIoT.ConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ApplicationContext context = new ApplicationContext(ConnectionStringProvider.GetConnectionString());

            IMessageRepository _mesaageRepository;
            IModuleIIoTRepository _moduleIIoTRepository;
            IUnityRepository _unityRepository;
            IUnitOfWork _unitOfWork;

            _moduleIIoTRepository = new ModuleIIoTRepository(context);
            _mesaageRepository = new MessageRepository(context);
            _unityRepository = new UnityRepository(context);
            _unitOfWork = new UnitOfWork(context);

            // creando entidades para probar mi base de datos

            ModuleIIoT module1 = new ModuleIIoT("MOdule LTE", "192.168.137.0");
            ModuleIIoT module2 = new ModuleIIoT("Module ZigBee", "68.96.105.4");
            ModuleIIoT module3 = new ModuleIIoT("Module CAM", "44.56.92.0");

            Message message1 = new Message("welcome", module1);
           // Message message2 = new Message("Hellow", module2);
           // Message message3 = new Message("bye", module1);

            Unity unity1 = new Unity("12345", "unidad 1");
            Unity unity2 = new Unity("9876", "unidad 2");
            Unity unity3 = new Unity("4567", "Unidad 3");

            // Añadiendo a la base de datos

            _moduleIIoTRepository.AddModuleIIoT(module1);
            _unitOfWork.SaveChages();
            _moduleIIoTRepository.AddModuleIIoT(module2);
            _unitOfWork.SaveChages();
            _moduleIIoTRepository.AddModuleIIoT(module3);
            _unitOfWork.SaveChages();

            _mesaageRepository.AdddMessage(message1);
            _unitOfWork.SaveChages();
            //_mesaageRepository.AdddMessage(message2);
            //_unitOfWork.SaveChages();
            //_mesaageRepository.AdddMessage(message3);
            //_unitOfWork.SaveChages();

            _unityRepository.AddUnity(unity1);
            _unitOfWork.SaveChages();
            _unityRepository.AddUnity(unity2);
            _unitOfWork.SaveChages();
            _unityRepository.AddUnity(unity3);
            _unitOfWork.SaveChages();



        }
    }
}
