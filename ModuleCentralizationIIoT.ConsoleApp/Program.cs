using Grpc.Net.Client;
using ModuleCentralizationIIoT.GrpcProtos;
using ModuleCentralizationIIoT.GrpcProtos.ModulesIIoT;

namespace ModuleCentralizationIIoT.ConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("Presione una tecla para conectar");
            Console.ReadKey();

            Console.WriteLine("Creating channel and client");
            var httpHandler = new HttpClientHandler();
            httpHandler.ServerCertificateCustomValidationCallback = HttpClientHandler.DangerousAcceptAnyServerCertificateValidator;

            var channel = GrpcChannel.ForAddress("http://localhost:5088", new GrpcChannelOptions { HttpHandler = httpHandler });
            if (channel is null)
            {
                Console.WriteLine("Cannot connect");
                channel.Dispose();
                return;
            }

            var client = new ModuleCentralizationIIoT.GrpcProtos.ModulesIIoT.ModuleIIoTclient(channel);
            //var client1 = new ModuleCentralizationIIoT.GrpcProtos.Message.Messageclient(channel);

            //var client = new CarDealer.GrpcProtos.Motorcycle.MotorcycleClient(channel);

            Console.WriteLine("Presione una tecla para crear una motocicleta");
            Console.ReadKey();
            var createResponse = client.CreateModule(new CreateModuleIIoTRequest()
            {
                Name = "Module ZigBee",
                AddressIp = "192.168.156.0",
            }
            );

            if (createResponse is null)
            {
                Console.WriteLine("Cannot create ModuleIIoT");
                channel.Dispose();
                return;
            }
            else
            {
                Console.WriteLine($"Creación exitosa.");
            }

            Console.WriteLine("Presione una tecla para obtener todos los modulos");
            Console.ReadKey();

            var getResponse = client.GetAllModuleIIoT(new Google.Protobuf.WellKnownTypes.Empty());
            if (getResponse.Items is null)
            {
                Console.WriteLine("Cannot get price");
                channel.Dispose();
                return;
            }
            else
            {
                Console.WriteLine($"Obtención exitosa de {getResponse.Items.Count} Modulos");
            }

            Console.WriteLine($"Presione una tecla para obtener el modulo con Id {createResponse.Id}");
            Console.ReadKey();
            var getByIdResponse = client.GetModuleIIoTById(new GetRequest() { Id = createResponse.Id.toString() });
            if (getByIdResponse is null)
            {
                Console.WriteLine("Cannot get Module");
                channel.Dispose();
                return;
            }
            else
            {
                Console.WriteLine($"Obtención exitosa de los modulos {getByIdResponse.ModuleIIoT.Brand}");
            }

            Console.WriteLine("Presione una tecla para modificar el modulo");
            Console.ReadKey();
            createResponse.Isconnected = true;
            client.UpdateModuleIIoT(createResponse);
            var updateResponse = client.GetModuleIIoT(new GetRequest() { Id = createResponse.Id });
            if (updateResponse is not null && updateResponse.XindCase == NullableModuleIIoTDTO.KindOneofCase.ModuleIIoT &&
                updateResponse.ModuleIIoT.Isconnected == createResponse.Isconnected)
            {
                Console.WriteLine($"modificacion exitosa");
            }
            Console.WriteLine("Presione una tecla para eliminar la motocicleta");
            Console.ReadKey();

            client.DeleteMOduleIIoT(new DeleteRequest() { Id = createResponse.Id });
            var deleteGetResponse = client.GetModuleIIoT((new GetRequest() { Id = createResponse.Id }));
            if (deleteGetResponse is null || deleteGetResponse.Kindcase != NullableModuleIIoTDTO.KindOneofCase.ModuleIIoT)
            {
                Console.WriteLine($"Eliminación exitosa.");
            }

            channel.Dispose();

        }
    }
}
