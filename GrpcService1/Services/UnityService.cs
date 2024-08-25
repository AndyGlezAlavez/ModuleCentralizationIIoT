using AutoMapper;
using Google.Protobuf.WellKnownTypes;
using Grpc.Core;
using MediatR;
using ModuleCentralizationIIoT.Application.UnityCQRS.Commands.CreateUnity;
using ModuleCentralizationIIoT.Contracts;
using ModuleCentralizationIIoT.GrpcProtos.Unity;
using ModuleCentralizationIIoT.GrpcProtos;

namespace GrpcService1.Services
{
    public class UnityService : Unity.UnityBase
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;


        //private readonly IMediator _mediator;
        //private readonly IMapper _mapper;

        //public MotorcycleService(
        //    IMediator mediator,
        //    IMapper mapper)
        //{
        //    _mediator = mediator;
        //    _mapper = mapper;
        //}

        public UnityService(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }
        public override Task<UnityDTO> CreateUnity(CreateUnityRequest request, ServerCallContext context)
        {
            //var command = new CreateMotorcycleCommand(
            //    request.Brand,
            //    (EnergySource)request.EnergySources,
            //    new Domain.ValueObjects.Price(
            //        (MoneyType)request.Price.MoneyType,
            //        request.Price.Value));

            //var result = _mediator.Send(command).Result;

            //return Task.FromResult(_mapper.Map<MotorcycleDTO>(result));
            var command = new CreateUnityCommand(
                request.Name,
                request.Code);
            var result = _mediator.Send(command).Result;

            return Task.FromResult(_mapper.Map<UnityDTO>(result));
        }
        public override Task<NullableUnityDTO> GetUnity(GetRequest request, ServerCallContext context)
        {
            return base.GetUnity(request, context);
        }
        public override Task<Unities> GetAllUnity(Empty request, ServerCallContext context)
        {
            return base.GetAllUnity(request, context);
        }
        public override Task<Empty> UpdateUnity(UnityDTO request, ServerCallContext context)
        {
            return base.UpdateUnity(request, context);
        }
        public override Task<Empty> DeleteUnity(DeleteRequest request, ServerCallContext context)
        {
            return base.DeleteUnity(request, context);
        }

        private readonly IUnityRepository _repository;
        private readonly IUnitOfWork _unitOfWork;

        public UnityService(IUnityRepository repository, IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
        }
    }
}
