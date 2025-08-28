using System.ComponentModel.DataAnnotations;

namespace ERP.API.Shared.Dtos;

public class ReadPacienteConvenioDto
{
    public string Convenio { get; set; }

    public DateTime DataVinculo { get; set; }
}
