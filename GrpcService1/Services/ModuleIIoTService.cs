#region    USINGS
using AutoMapper;
using Google.Protobuf.WellKnownTypes;
using Grpc.Core;
using MediatR;
using ModuleCentralizationIIoT.Application.ModuleCQRS.Commands.CreateModuleIIoT;
using ModuleCentralizationIIoT.Application.ModuleCQRS.Commands.DeleteModuleIIoT;
using ModuleCentralizationIIoT.Application.ModuleCQRS.Commands.UpdateModuleIIoT;
using ModuleCentralizationIIoT.Application.ModuleCQRS.Queries.GetAllModuleIIoT;
using ModuleCentralizationIIoT.Application.ModuleCQRS.Queries.GetModuleIIoTById;
using ModuleCentralizationIIoT.Application.UnityCQRS.Commands.UpdateUnity;
using ModuleCentralizationIIoT.Contracts;
using ModuleCentralizationIIoT.GrpcProtos;
using ModuleCentralizationIIoT.GrpcProtos.ModulesIIoT;
#endregion

namespace GrpcService1.Services
{
    public class ModuleIIoTService : ModuleIIoT.ModuleIIoTBase
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public ModuleIIoTService(IMediator mediator, IMapper mapper)
        {
            _mapper = mapper;
            _mediator = mediator;
        }

        public override Task<ModuleIIoTDTO> CreateModuleIIoT(CreateModuleIIoTRequest request, ServerCallContext context)
        {
            var command = new CreateModuleIIoTCommand(
                request.Name,
                request.AddressIp);

            var result = _mediator.Send(command).Result;

            return Task.FromResult(_mapper.Map<ModuleIIoTDTO>(result));
        }
        public override Task<NullableModuleIIoTDTO> GetModuleIIoT(GetRequest request, ServerCallContext context)
        {
            var query = new GetModuleIIoTByIdQuery(new Guid(request.Id));

            var result = _mediator.Send(query).Result;

            if (result is null)
                return Task.FromResult(new NullableModuleIIoTDTO() { Null = NullValue.NullValue });
            return Task.FromResult(new NullableModuleIIoTDTO() { ModuleIIoT = _mapper.Map<ModuleIIoTDTO>(result) });
        }
        public override Task<ModulesIIoT> GetAllModuleIIoT(Empty request, ServerCallContext context)
        {
            var query = new GetAllModuleIIoTQuery();

            var result = _mediator.Send(query).Result;

            var moduleIIoTDTOs = new ModulesIIoT();

            moduleIIoTDTOs.Items.AddRange(result.Select(m => _mapper.Map<ModuleIIoTDTO>(request)));

            return Task.FromResult(moduleIIoTDTOs);
        }
        public override Task<Empty> UpdateModuleIIoT(ModuleIIoTDTO request, ServerCallContext context)
        {
            var command = new UpdateModuleIIoTCommand(_mapper.Map<ModuleCentralizationIIoT.Domain.Entities.ModuleIIoT>(request));

            _mediator.Send(command);

            return Task.FromResult(new Empty());
        }
        public override Task<Empty> DeleteModuleIIoT(DeleteRequest request, ServerCallContext context)
        {
            var command = new DeleteModuleIIoTCommand(new Guid (request.Id));

            _mediator.Send(command);

            return Task.FromResult(new Empty());
        }


    }
}
