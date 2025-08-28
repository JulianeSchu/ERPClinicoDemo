using ERP.API.Domain.Models;
using ERP.API.Models;


namespace ERP.API.Shared.Dtos;

public class ReadAgendamentoDto
{
    public Guid Id { get; set; }
    public string Paciente { get; set; }
    public string Profissional { get; set; }
    public string Convenio { get; set; }
    public DateTime DataHoraInicio { get; set; }
    public DateTime DataHoraFim { get; set; }
    public string TipoConsulta { get; set; }
    public string Status { get; set; }
    public string? Observacoes { get; set; }
    public List<string> Procedimentos { get; set; }

}
