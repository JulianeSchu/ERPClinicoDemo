using System.ComponentModel.DataAnnotations;

namespace ERP.API.Shared.Dtos;

public class PacienteConvenioDto
{
    [Required]
    public Guid ConvenioId { get; set; }
    public string Convenio { get; set; }

    [Required]
    public DateTime DataVinculo { get; set; }
}
