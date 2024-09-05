using AutoMapper;
using Google.Protobuf.WellKnownTypes;
using Grpc.Core;
using MediatR;
using ModuleCentralizationIIoT.GrpcProtos.Message;
using ModuleCentralizationIIoT.GrpcProtos;
using ModuleCentralizationIIoT.Application.MessageCQRS.Commands.CreateMessage;
using ModuleCentralizationIIoT.Application.MessageCQRS.Commands.DeleteMessage;
using ModuleCentralizationIIoT.Application.UnityCQRS.Queries.GetAllUnity;
using ModuleCentralizationIIoT.Application.UnityCQRS.Queries.GetUnityById;
using ModuleCentralizationIIoT.Application.MessageCQRS.Commands.UpdateMessage;

namespace GrpcService1.Services
{
    
    public class MessageService : Message.MessageBase
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public MessageService(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        public override Task<MessageDTO> CreateMessage(CreateMessageRequest request, ServerCallContext context)
        {
            var command = new CreateMessageCommand(
                request.Text,
                _mapper.Map<ModuleCentralizationIIoT.Domain.Entities.ModuleIIoT>(request.ModuleIIoT));

            var result = _mediator.Send(command).Result;
            result.CreationMessage = DateTime.SpecifyKind(result.CreationMessage, DateTimeKind.Local).ToUniversalTime();
            return Task.FromResult(_mapper.Map<MessageDTO>(result));
        }
        public override Task<NullableMessageDTO> GetMessage(GetRequest request, ServerCallContext context)
        {
            var query = new GetUnityByIdQuery(new Guid(request.Id));

            var result = _mediator.Send(query).Result;

            if (result == null) 
                return Task.FromResult(new NullableMessageDTO() { Message = _mapper.Map<MessageDTO>(result) });
            return Task.FromResult(new NullableMessageDTO() { Message= _mapper.Map<MessageDTO>(result) }) ;
        }
        public override Task<Messages> GetAllMessages(Empty request, ServerCallContext context)
        {
            var query = new GetAllUnityQuery();

            var result = _mediator.Send(query).Result;

            var messageDTOS = new Messages();

            messageDTOS.Items.AddRange(result.Select(m=>_mapper.Map<MessageDTO>(request)));

            return Task.FromResult(messageDTOS);
        }
        public override Task<Empty> UpdateMessage(MessageDTO request, ServerCallContext context)
        {
            var command = new UpdateMessageCommand(_mapper.Map<ModuleCentralizationIIoT.Domain.Entities.Message>(request));

            _mediator.Send(command);

            return Task.FromResult(new Empty());
        }
        public override Task<Empty> DeleteMessage(DeleteRequest request, ServerCallContext context)
        {
            var command = new DeleteMessageCommand(new Guid(request.Id));

            _mediator.Send(command);

            return Task.FromResult(new Empty());
        }
    }
    
}
