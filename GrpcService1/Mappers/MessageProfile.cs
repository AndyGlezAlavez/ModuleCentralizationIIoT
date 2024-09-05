using AutoMapper;
using Google.Protobuf.WellKnownTypes;


namespace GrpcService1.Mappers
{
    public class MessageProfile: Profile
    {
        public MessageProfile()
        {
            CreateMap<ModuleCentralizationIIoT.Domain.Entities.Message,
                ModuleCentralizationIIoT.GrpcProtos.Message.MessageDTO>()
                .ForMember(t => t.Id, o => o.MapFrom(s => s.Id.ToString()))
                .ForMember(t => t.Text, o => o.MapFrom(s => s.Text))
                .ForMember(t => t.Priority, o => o.MapFrom(s => (ModuleCentralizationIIoT.GrpcProtos.Priority)s.Priority))
                .ForMember(t => t.ModuleIIoT, o => o.MapFrom(s => s.ModuleIIoT))
                .ForMember(t=>t.CreationMessage,o=>o.MapFrom(s=>Timestamp.FromDateTime(s.CreationMessage)))
                 ;

            CreateMap<ModuleCentralizationIIoT.GrpcProtos.Message.MessageDTO,
                ModuleCentralizationIIoT.Domain.Entities.Message>()
                .ForMember(t=>t.Id, o =>o.MapFrom(s=>new Guid(s.Id)))
                .ForMember(t=>t.Text,o=>o.MapFrom(s=>s.Text))
                .ForMember(t=>t.Priority,o=>o.MapFrom(s=>(ModuleCentralizationIIoT.Domain.Entities.Types.Priority)s.Priority))
                .ForMember(t=>t.ModuleIIoT,o=>o.MapFrom(s=> s.ModuleIIoT))
                .ForMember(t=>t.CreationMessage,o=>o.MapFrom(s=>s.CreationMessage.ToDateTime()))
                ;
        }
    }
}
