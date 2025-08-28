using AutoMapper;
using ERP.API.Domain.Models;
using ERP.API.Shared.Dtos;


namespace ERP.API.Profiles;

public class AgendamentosProfile : Profile
{
    public AgendamentosProfile()
    {

        CreateMap<CreateAgendamentoDto, Agendamento>();
        CreateMap<Agendamento, ReadAgendamentoDto>()
            .ForMember(dest => dest.Paciente,
                opt => opt.MapFrom(src => src.Paciente.NomeCompleto)) // ou outro campo representativo
            .ForMember(dest => dest.Profissional,
                opt => opt.MapFrom(src => src.Profissional.NomeCompleto)) // mesmo aqui
            .ForMember(dest => dest.Convenio,
                opt => opt.MapFrom(src => src.Convenios != null ? src.Convenios.Nome : "Particular")) // trata null
            .ForMember(dest => dest.Procedimentos,
                opt => opt.MapFrom(src => src.AgendamentosProcedimentos
                    .Select(ap => ap.Procedimento.Nome).ToList()));
        CreateMap<UpdateAgendamentoDto, Agendamento>();
    }
}

