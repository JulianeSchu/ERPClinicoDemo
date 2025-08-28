using AutoMapper;
using ERP.API.Domain.Models;
using ERP.API.Shared.Dtos;

namespace ERP.API.Profiles;

public class ProcedimentoProfile : Profile
{
    public ProcedimentoProfile()
    {
        CreateMap<CreateProcedimentoDto, Procedimento>();
        CreateMap<Procedimento, ReadProcedimentoDto>();
        CreateMap<UpdateProcedimentoDto, Procedimento>();
    }
}