using ERP.API.Domain.Enums;
using ERP.API.Domain.Models;
using ERP.API.Enums;
using ERP.API.Models;
using System.ComponentModel.DataAnnotations;

namespace ERP.API.Domain.Models;

public class Agendamento
{
    [Key]
    [Required]
    public Guid Id { get; set; }
    [Required]
    public Guid PacienteId { get; set; }
    [Required]
    public Guid ProfissionalId { get; set; }
    [Required]
    public DateTime DataHoraInicio { get; set; }
    [Required]
    public DateTime DataHoraFim { get; set; }
    [Required]
    public TipoConsulta TipoConsulta { get; set; } // Ex: "Presencial", "Retorno", "Teleconsulta"
    [Required]
    public Status Status { get; set; }       // Ex: "Agendado", "Cancelado", "Realizado"
                                             // Chave estrangeira para Convênio
    public Guid ConvenioId { get; set; }


    public string? Observacoes { get; set; }
    public ICollection<AgendamentoProcedimento> AgendamentosProcedimentos { get; set; } = new List<AgendamentoProcedimento>();
    public Paciente Paciente { get; internal set; }
    public Profissional Profissional { get; internal set; }
    public Convenio Convenios { get; internal set; }
}
