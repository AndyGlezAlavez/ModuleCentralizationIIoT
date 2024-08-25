using AutoMapper;


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
                .ForMember(t => t.ModuleIIoT, o => o.MapFrom(s => new ModuleCentralizationIIoT.GrpcProtos.ModulesIIoT.ModuleIIoTDTO()
                {
                    Id = s.ModuleIIoT.Id.ToString(),
                    Name = s.ModuleIIoT.Name,
                    AddressIp = s.ModuleIIoT.AddressIp,

                }))
                .ForMember(t=>t.CreationMessage,o=>o.MapFrom(s=>s.CreationMessage));
            CreateMap<ModuleCentralizationIIoT.GrpcProtos.Message.MessageDTO,
                ModuleCentralizationIIoT.Domain.Entities.Message>()
                .ForMember(t=>t.Id, o =>o.MapFrom(s=>new Guid(s.Id)))
                .ForMember(t=>t.Text,o=>o.MapFrom(s=>s.Text))
                .ForMember(t=>t.ModuleIIoT,o=>o.MapFrom(s=> new ModuleCentralizationIIoT.Domain.Entities.ModuleIIoT(
                    new Guid(s.ModuleIIoT.Id),
                    s.ModuleIIoT.Name,
                    s.ModuleIIoT.AddressIp)))
                .ForMember(t=>t.CreationMessage,o=>o.MapFrom(s=>s.CreationMessage));
        }
    }
}
