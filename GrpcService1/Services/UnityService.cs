using AutoMapper;
using Google.Protobuf.WellKnownTypes;
using Grpc.Core;
using MediatR;
using ModuleCentralizationIIoT.Application.UnityCQRS.Commands.CreateUnity;
using ModuleCentralizationIIoT.Contracts;
using ModuleCentralizationIIoT.GrpcProtos.Unity;
using ModuleCentralizationIIoT.GrpcProtos;
using ModuleCentralizationIIoT.Application.UnityCQRS.Commands.DeleteUnity;
using ModuleCentralizationIIoT.Application.UnityCQRS.Commands.UpdateUnity;
using ModuleCentralizationIIoT.Application.UnityCQRS.Queries.GetAllUnity;
using ModuleCentralizationIIoT.Application.ModuleCQRS.Queries.GetModuleIIoTById;
using ModuleCentralizationIIoT.GrpcProtos.ModulesIIoT;
using ModuleCentralizationIIoT.Application.UnityCQRS.Queries.GetUnityById;

namespace GrpcService1.Services
{
    public class UnityService : Unity.UnityBase
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;


        public UnityService(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        private readonly IUnityRepository _repository;
        private readonly IUnitOfWork _unitOfWork;

        public UnityService(IUnityRepository repository, IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
        }

        public override Task<UnityDTO> CreateUnity(CreateUnityRequest request, ServerCallContext context)
        {
            var command = new CreateUnityCommand(
                request.Name,
                request.Code);
            var result = _mediator.Send(command).Result;

            return Task.FromResult(_mapper.Map<UnityDTO>(result));
        }
        public override Task<NullableUnityDTO> GetUnity(GetRequest request, ServerCallContext context)
        {
             var query = new GetUnityByIdQuery(new Guid(request.Id));

            var result = _mediator.Send(query).Result;

            if (result == null) 
                return Task .FromResult(new NullableUnityDTO() { Null = NullValue.NullValue});
            return Task.FromResult(new NullableUnityDTO() { Unity = _mapper.Map<UnityDTO>(result) });

        }
        public override Task<Unities> GetAllUnity(Empty request, ServerCallContext context)
        {
            var query = new GetAllUnityQuery();

            var result = _mediator.Send(query).Result;

            var unityDTOs = new Unities();

            unityDTOs.Items.AddRange(result.Select(m => _mapper.Map<UnityDTO>(request)));

            return Task.FromResult(unityDTOs);
        }
        public override Task<Empty> UpdateUnity(UnityDTO request, ServerCallContext context)
        {
            var command = new UpdateUnityCommand(_mapper.Map<ModuleCentralizationIIoT.Domain.Entities.Unity>(request));
           
            _mediator.Send(command);
            
            return Task.FromResult(new Empty());
        }
        public override Task<Empty> DeleteUnity(DeleteRequest request, ServerCallContext context)
        {
            var command = new DeleteUnityCommand(new Guid(request.Id));

            _mediator.Send(command);

            return Task.FromResult(new Empty());
        }


    }
}
