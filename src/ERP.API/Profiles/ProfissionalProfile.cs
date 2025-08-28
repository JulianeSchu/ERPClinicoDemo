using AutoMapper;
using ERP.API.Models;
using ERP.API.Shared.Dtos;
namespace ERP.API.Profiles;

public class ProfissionalProfile : Profile
{
    public ProfissionalProfile()
    {
        CreateMap<CreateProfissionalDto, Profissional>();
        CreateMap<Profissional, ReadProfissionalDto>();
        CreateMap<UpdateProfissionalDto, Profissional>();
    }
}
