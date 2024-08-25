using AutoMapper;
using Google.Protobuf.WellKnownTypes;
using Grpc.Core;
using MediatR;
using ModuleCentralizationIIoT.Application.ModuleCQRS.Commands.CreateModuleIIoT;
using ModuleCentralizationIIoT.Application.ModuleCQRS.Queries.GetModuleIIoTById;
using ModuleCentralizationIIoT.Contracts;
using ModuleCentralizationIIoT.GrpcProtos;
using ModuleCentralizationIIoT.GrpcProtos.ModulesIIoT;

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

            //var command = new CreateMotorcycleCommand(
            //    request.Brand,
            //    (EnergySource)request.EnergySources,
            //    new Domain.ValueObjects.Price(
            //        (MoneyType)request.Price.MoneyType,
            //        request.Price.Value));

            //var result = _mediator.Send(command).Result;

            //return Task.FromResult(_mapper.Map<MotorcycleDTO>(result));
            var command = new CreateModuleIIoTCommand(
                request.Name,
                request.AddressIp);

            var result = _mediator.Send(command).Result;

            return Task.FromResult(_mapper.Map<ModuleIIoTDTO>(result));
        }
        public override Task<NullableModuleIIoTDTO> GetModuleIIoT(GetRequest request, ServerCallContext context)
        {
            //var query = new GetMotorcycleByIdQuery(new Guid(request.Id));

            //var result = _mediator.Send(query).Result;

            //if (result is null)
            //    return Task.FromResult(new NullableMotorcycleDTO() { Null = NullValue.NullValue });
            //return Task.FromResult(new NullableMotorcycleDTO() { Motorcycle = _mapper.Map<MotorcycleDTO>(result) });

            var query = new GetModuleIIoTByIdQuery(new Guid(request.Id));

            var result = _mediator.Send(query).Result;

            if (result is null)
                return Task.FromResult(new NullableModuleIIoTDTO() { Null = NullValue.NullValue });
            return Task.FromResult(new NullableModuleIIoTDTO() { ModuleIIoT = _mapper.Map<ModuleIIoTDTO>(result) });
        }
        public override Task<ModulesIIoT> GetAllModuleIIoT(Empty request, ServerCallContext context)
        {
            return base.GetAllModuleIIoT(request, context);
        }
        public override Task<Empty> UpdateModuleIIoT(ModuleIIoTDTO request, ServerCallContext context)
        {
            return base.UpdateModuleIIoT(request, context);
        }
        public override Task<Empty> DeleteModuleIIoT(DeleteRequest request, ServerCallContext context)
        {
            return base.DeleteModuleIIoT(request, context);
        }

        private readonly IModuleIIoTRepository _moduleIIoTRepository;
        private readonly IUnitOfWork _unitOfWork;

        public ModuleIIoTService(IModuleIIoTRepository moduleIIoTRepository, IUnitOfWork unitOfWork)
        {
            _moduleIIoTRepository = moduleIIoTRepository;
            _unitOfWork = unitOfWork;
        }
    }
}
