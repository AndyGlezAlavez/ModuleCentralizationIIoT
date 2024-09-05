using AutoMapper;
using ModuleCentralizationIIoT.Domain;
using ModuleCentralizationIIoT.GrpcProtos;

namespace GrpcService1.Mappers
{
    public class UnityProfile : Profile
    {
        public UnityProfile()
        {
            CreateMap<ModuleCentralizationIIoT.Domain.Entities.Unity ,
            ModuleCentralizationIIoT.GrpcProtos.Unity.UnityDTO>()
                .ForMember(t => t.Id, o => o.MapFrom(s => s.Id.ToString()))
                .ForMember(t => t.Area, o => o.MapFrom(s => s.Area))
                .ForMember(t => t.Name, o => o.MapFrom((s) => s.Name))
                .ForMember(t => t.Code, o => o.MapFrom((t) => t.Code));

            CreateMap<ModuleCentralizationIIoT.GrpcProtos.Unity.UnityDTO,
                ModuleCentralizationIIoT.Domain.Entities.Unity>()
                .ForMember(t => t.Id, o => o.MapFrom(s => new Guid(s.Id)))
                .ForMember(t => t.Name, o => o.MapFrom(s => s.Name))
                .ForMember(t => t.Area, o => o.MapFrom(s => s.Area))
                .ForMember(t => t.Code, o => o.MapFrom(s => s.Code));
        }
    }
}
