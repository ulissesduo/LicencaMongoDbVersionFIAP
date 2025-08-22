using AutoMapper;
using MongoDB.Bson;
using webapiMongoDB.Dto;
using webapiMongoDB.Model;

namespace webapiMongoDB.Mapper
{
    public class LicencaProfile : Profile
    {
        public LicencaProfile()
        {
            CreateMap<LicencaRequestDTO, Licenca>()
                .ForMember(dest => dest.Data_emissao, opt => opt.MapFrom(src => src.Data_emissao.ToDateTime(TimeOnly.MinValue)))
                .ForMember(dest => dest.Data_validade, opt => opt.MapFrom(src => src.Data_validade.ToDateTime(TimeOnly.MinValue))) 
                .ForMember(dest => dest.IdEmpresa, opt => opt.MapFrom(src =>
                    string.IsNullOrEmpty(src.IdEpresa.ToString())
                    ? ObjectId.GenerateNewId().ToString()
                    : src.IdEpresa.ToString()));

            CreateMap<Licenca, LicencaResponseDTO>()
                .ForMember(dest => dest.Data_emissao, opt => opt.MapFrom(src => DateOnly.FromDateTime(src.Data_emissao)))
                .ForMember(dest => dest.Data_validade, opt => opt.MapFrom(src => DateOnly.FromDateTime(src.Data_validade)))
                .ForMember(dest => dest.IdEpresa, opt => opt.MapFrom(src => src.IdEmpresa)); 
        }
    }
}
