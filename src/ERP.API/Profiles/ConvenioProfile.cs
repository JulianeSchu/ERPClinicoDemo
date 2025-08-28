using AutoMapper;
using ERP.API.Domain.Models;
using ERP.API.Shared.Dtos;
namespace ERP.API.Profiles;

public class ConvenioProfile : Profile
{
    public ConvenioProfile()
    {
        CreateMap<Convenio, ReadConvenioDto>();
        CreateMap<CreateConvenioDto, Convenio>();
        CreateMap<UpdateConvenioDto, Convenio>();
    }
}
