using AutoMapper;

namespace GrpcService1.Mappers
{
    public class ModuleIIoTProfile : Profile
    {
        public ModuleIIoTProfile() 
        {
            CreateMap<ModuleCentralizationIIoT.Domain.Entities.ModuleIIoT,
                ModuleCentralizationIIoT.GrpcProtos.ModulesIIoT.ModuleIIoTDTO>()
                .ForMember(t => t.Id, o => o.MapFrom(s => s.Id.ToString()))
                .ForMember(t => t.Name, o => o.MapFrom(s => s.Name))
                .ForMember(t => t.AddressIp, o => o.MapFrom(s => s.AddresIp))
                .ForMember(t=>t.Accessport,o=>o.MapFrom(s=>s.AccessPort));

            CreateMap<ModuleCentralizationIIoT.GrpcProtos.ModulesIIoT.ModuleIIoTDTO,
                ModuleCentralizationIIoT.Domain.Entities.ModuleIIoT>()
                .ForMember(t => t.Id, o => o.MapFrom(s => new Guid(s.Id)))
                .ForMember(t => t.Name, o => o.MapFrom(s => s.Name))
                .ForMember(t => t.AddresIp, o => o.MapFrom(s => s.AddressIp))
                .ForMember(t=>t.AccessPort,o=>o.MapFrom(s=>s.Accessport));

        }
    }
}
