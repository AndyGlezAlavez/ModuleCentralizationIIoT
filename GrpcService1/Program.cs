using GrpcService1.Services;
using ModuleCentralizationIIoT.Contracts;
using ModuleCentralizationIIoT.DataAccess;
using ModuleCentralizationIIoT.DataAccess.Contexts;
using ModuleCentralizationIIoT.DataAccess.Repositories;
using System.Reflection.Metadata;
using MediatR;



namespace GrpcService1
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Additional configuration is required to successfully run gRPC on macOS.
            // For instructions on how to configure Kestrel and gRPC clients on macOS, visit https://go.microsoft.com/fwlink/?linkid=2099682

            // Add services to the container.
            builder.Services.AddGrpc(options => { options.EnableDetailedErrors = true;
                options.MaxReceiveMessageSize = 2 * 1024 * 1024;//2mb
                options.MaxSendMessageSize = 5 * 1024 * 1024;
            });

            builder.Services.AddAutoMapper(typeof(Program).Assembly);
            builder.Services.AddMediatR(new MediatRServiceConfiguration()
            {
                AutoRegisterRequestProcessors = true,
            }
            .RegisterServicesFromAssemblies(typeof(AssemblyReference).Assembly));

            builder.Services.AddSingleton("Data Source = Data,sqlite");
            builder.Services.AddScoped<ApplicationContext>();
            builder.Services.AddScoped<IUnitOfWork,UnitOfWork>();
            builder.Services.AddScoped<IMessageRepository, MessageRepository>();
            builder.Services.AddScoped<IModuleIIoTRepository, ModuleIIoTRepository>();
            builder.Services.AddScoped<IUnityRepository, UnityRepository>();


            var app = builder.Build();

            // Configure the HTTP request pipeline.

            app.MapGrpcService<ModuleIIoTService>();
            app.MapGrpcService<MessageService>();
            app.MapGrpcService<UnityService>();

            app.MapGet("/", () => "Communication with gRPC endpoints must be made through a gRPC client. To learn how to create a client, visit: https://go.microsoft.com/fwlink/?linkid=2086909");

            app.Run();
        }
    }
}