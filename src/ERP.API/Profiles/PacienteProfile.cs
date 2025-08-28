using AutoMapper;
using ERP.API.Domain.Models;
using ERP.API.Shared.Dtos;
namespace ERP.API.Profiles;

public class PacienteProfile : Profile
{
    public PacienteProfile()
    {
        CreateMap<CreatePacienteDto, Paciente>();
        CreateMap<UpdatePacienteDto, Paciente>();

        CreateMap<PacienteConvenio, ReadPacienteConvenioDto>()
            .ForMember(dest => dest.Convenio, opt => opt.MapFrom(src => src.Convenio.Nome))
            .ForMember(dest => dest.DataVinculo, opt => opt.MapFrom(src => src.DataVinculo));

        CreateMap<Paciente, ReadPacienteDto>()
            .ForMember(dest => dest.Convenios, opt => opt.MapFrom(src => src.PacienteConvenios));
    }
}
