using AutoMapper;
using Google.Protobuf.WellKnownTypes;
using Grpc.Core;
using MediatR;
using ModuleCentralizationIIoT.GrpcProtos.Message;
using ModuleCentralizationIIoT.GrpcProtos;

namespace GrpcService1.Services
{
    public class MessageService
    {
        public class MesageServvice : Message.MessageBase
        {
            private readonly IMediator _mediator;
            private readonly IMapper _mapper;

            public MesageServvice(IMediator mediator, IMapper mapper)
            {
                _mediator = mediator;
                _mapper = mapper;
            }

            public override Task<MessageDTO> CreateMessage(CreateMessageRequest request, ServerCallContext context)
            {
                return base.CreateMessage(request, context);
            }

            //public override Task<MessageDTO> CreateMessage(CreateMessageRequest request, ServerCallContext context)
            //{
            //    var command = new CreateModuleIIoTCommand(
            //        request.Text,
            //        request.ModuleIIoT);

            //    var result = _mediator.Send(command).Result;

            //    return Task.FromResult(_mapper.Map<MessageDTO>(result));
            //}
            public override Task<NullableMessageDTO> GetMessage(GetRequest request, ServerCallContext context)
            {
                return base.GetMessage(request, context);
            }
            public override Task<Messages> GetAllMessages(Empty request, ServerCallContext context)
            {
                return base.GetAllMessages(request, context);
            }
            public override Task<Empty> UpdateMessage(MessageDTO request, ServerCallContext context)
            {
                return base.UpdateMessage(request, context);
            }
            public override Task<Empty> DeleteMessage(DeleteRequest request, ServerCallContext context)
            {
                return base.DeleteMessage(request, context);
            }
        }
    }
}
