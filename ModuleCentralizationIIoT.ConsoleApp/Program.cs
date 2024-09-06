using Grpc.Net.Client;
using ModuleCentralizationIIoT.GrpcProtos;
using ModuleCentralizationIIoT.GrpcProtos.Message;
using ModuleCentralizationIIoT.GrpcProtos.ModulesIIoT;
using ModuleCentralizationIIoT.GrpcProtos.Unity;
using System.Threading.Channels;

namespace ModuleCentralizationIIoT.ConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Inicio del programa
            Console.WriteLine("Presione una tecla para conectar");
            Console.ReadKey();
            
            //Creando un canal y un cliente
            Console.WriteLine("Creating channel and client");
            var httpHandler = new HttpClientHandler();
            httpHandler.ServerCertificateCustomValidationCallback = HttpClientHandler.DangerousAcceptAnyServerCertificateValidator;
            var channel = GrpcChannel.ForAddress("http://localhost:7200", new GrpcChannelOptions { HttpHandler = httpHandler });

            //Error en la creación del canal, retorno
            if (channel is null)
            {
                Console.WriteLine("Cannot connect");
                channel.Dispose();
                return;
            }

            var ModuleClient = new ModuleIIoT.ModuleIIoTClient(channel);
            var MessageClient = new Message.MessageClient(channel);
            var UnityClient = new Unity.UnityClient(channel);

            //bool cicle = true;
            //string OptionSelect = "";
            //string DateTypeSelect = "";




            //MODULOOOOOO
            Console.WriteLine("Presione una tecla para Crear el modulo");
            Console.ReadKey();
            var createResponse = ModuleClient.CreateModuleIIoT(new CreateModuleIIoTRequest()
            {
                Name = "Module ZigBee",
                AddressIp = "192.168.156.0",
            }
            );

            //Fallo en la creación del módulo, retorno
            if (createResponse is null)
            {
                Console.WriteLine("Cannot create ModuleIIoT");
                channel.Dispose();
                return;
            }
            
            //Módulo creado
            else
            {
                Console.WriteLine($"Creación exitosa.");
            }



            //MENSAGEEEEEEEE
            Console.WriteLine("Presione una tecla para Crear el message");
            Console.ReadKey();
            var createResponse1 = MessageClient.CreateMessage(new CreateMessageRequest()
            {
                Text = "Hello",
                ModuleIIoT = createResponse

            });

            //Fallo en la creación del mensaje, retorno.
            if (createResponse is null)
            {
                Console.WriteLine("Cannot create message");
                channel.Dispose();
                return;
            }

            //Mensaje creado
            else
            {
                Console.WriteLine($"Creación exitosa.");
            }




            //UNIDADDDDDDDDDD
            Console.WriteLine("Presione una tecla para Crear la unidad");
            Console.ReadKey();

            var createResponse2 = UnityClient.CreateUnity(new CreateUnityRequest()
            {
                Code = "1234",
                Name = "unity"

            });

            //Fallo en la creación de la unidad, retorno.
            if (createResponse2 is null)
            {
                Console.WriteLine("Cannot create ModuleIIoT");
                channel.Dispose();
                return;
            }

            //Unidad creada
            else
            {
                Console.WriteLine($"Creación exitosa.");
            }

            

            //Obteniendo un módulo por su Id
            Console.WriteLine($"Presione una tecla para obtener el modulo con Id {createResponse.Id}");
            Console.ReadKey();
            var getByIdResponse = ModuleClient.GetModuleIIoT(new GetRequest() { Id = createResponse.Id.ToString() });
           
            //Fallo en la obtención del módulo, retorno
            if (getByIdResponse is null)
            {
                Console.WriteLine("Cannot get Module");
                channel.Dispose();
                return;
            }

            //Módulo obtenido por Id
            else
            {
                Console.WriteLine($"Obtención exitosa de los modulos {getByIdResponse.ModuleIIoT.Name}");
            }
            //Console.WriteLine($"Presione una tecla para obtener el Message con Id {createResponse1.Id}");
            //Console.ReadKey();


            //Obteniendo unidad por su Id.
            Console.WriteLine($"Presione una tecla para obtener el unity con Id {createResponse2.Id}");
            Console.ReadKey();
            var getByIdResponse2 = UnityClient.GetUnity(new GetRequest() { Id = createResponse2.Id.ToString() });

            //Fallo en la obtención de la unidad, retorno
            if (getByIdResponse2 is null)
            {
                Console.WriteLine("Cannot get Uinty");
                channel.Dispose();
                return;
            }

            //Unidad obtenida por Id
            else
            {
                Console.WriteLine($"Obtención exitosa de las unidades {getByIdResponse2.Unity.Name}");
            }


            
            //Modificando un módulo.
            Console.WriteLine("Presione una tecla para modificar el modulo");
            Console.ReadKey();
            createResponse.IsConnected = true;
            //Actualizando módulo modificado en base de datos.
            ModuleClient.UpdateModuleIIoT(createResponse);
            var updateResponse = ModuleClient.GetModuleIIoT(new GetRequest() { Id = createResponse.Id });
            if (updateResponse is not null &&
                 updateResponse.KindCase == NullableModuleIIoTDTO.KindOneofCase.ModuleIIoT &&
                 updateResponse.ModuleIIoT.IsConnected == createResponse.IsConnected)
            {
                Console.WriteLine($"modificacion exitosa");
            }

            //MENSAGEEEEEEE
            //Console.WriteLine("Presione una tecla para modificar el modulo");
            //Console.ReadKey();
            //createResponse.IsConnected = true;
            //ModuleClient.UpdateModuleIIoT(createResponse);
            //MessageClient.UpdateMessage(createResponse1);
            //var updateResponse1 = MessageClient.GetMessage(new GetRequest() { Id = createResponse1.Id });
            //if (updateResponse1 is not null &&
            //     updateResponse1.KindCase == NullableModuleIIoTDTO.KindOneofCase.ModuleIIoT &&
            //     updateResponse1.ModuleIIoT.IsConnected == createResponse.IsConnected)
            //{
            //    Console.WriteLine($"modificacion exitosa");
            //}


            
            
            //Modificando una unidad
            Console.WriteLine("Presione una tecla para modificar la unidad");
            Console.ReadKey();
            createResponse2.Area = "prueba";
            //Actualizando en base de datos, unidad modificada.
            UnityClient.UpdateUnity(createResponse2);
            var updateResponse2 = UnityClient.GetUnity(new GetRequest() { Id = createResponse2.Id });
            if (updateResponse2 is not null &&
                updateResponse2.KindCase == NullableUnityDTO.KindOneofCase.Unity &&
                updateResponse2.Unity.Area == createResponse2.Area)
            {
                Console.WriteLine($"modificacion exitosa");
            }

           


            //Eliminando un módulo.
            Console.WriteLine("Presione una tecla para eliminar el modulo");
            Console.ReadKey();

            ModuleClient.DeleteModuleIIoT(new DeleteRequest() { Id = createResponse.Id });
            var deleteGetResponse = ModuleClient.GetModuleIIoT((new GetRequest() { Id = createResponse.Id }));
            if (deleteGetResponse is null || deleteGetResponse.KindCase != NullableModuleIIoTDTO.KindOneofCase.ModuleIIoT)
            {
                Console.WriteLine($"Eliminación exitosa.");
            }

            //MENSAGEEEEEEEE
            //Console.WriteLine("Presione una tecla para eliminar el mensaje");
            //Console.ReadKey();

            //MessageClient.DeleteMessage(new DeleteRequest() { Id = createResponse1.Id });
            //var deleteGetResponse1 = MessageClient.GetMessage((new GetRequest() { Id = createResponse1.Id }));
            //if (deleteGetResponse1 is null || deleteGetResponse1.KindCase != NullableMessageDTO.KindOneofCase.Message)
            //{
            //    Console.WriteLine($"Eliminación exitosa.");
            //}


            //Eliminando una unidad
            Console.WriteLine("Presione una tecla para eliminar la unidad");
            Console.ReadKey();
            UnityClient.DeleteUnity(new DeleteRequest() { Id = createResponse2.Id });

            var deleteGetResponse2 = UnityClient.GetUnity((new GetRequest() { Id = createResponse2.Id }));
            if (deleteGetResponse2 is null || deleteGetResponse2.KindCase != NullableUnityDTO.KindOneofCase.Unity)
            {
                Console.WriteLine($"Eliminación exitosa.");
            }

            channel.Dispose();


        }
    }
}

