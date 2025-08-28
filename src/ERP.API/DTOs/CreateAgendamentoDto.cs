using ERP.API.Domain.Enums;
using ERP.API.Domain.Models;
using ERP.API.Enums;
using ERP.API.Models;
using System.ComponentModel.DataAnnotations;

namespace ERP.API.Shared.Dtos;

public class CreateAgendamentoDto
{
    [Required(ErrorMessage = "O campo Paciente é obrigatorio.")]
    public Guid PacienteId { get; set; }
    [Required(ErrorMessage = "O campo de Profisional é obrigatorio.")]
    public Guid ProfissionalId { get; set; }
    [Required(ErrorMessage = "O campo de Procedimento é obrigatorio.")]
    public DateTime DataHoraInicio { get; set; }
    [Required(ErrorMessage = "O campo de Data/Hora de Fim é obrigatorio.")]
    public DateTime DataHoraFim { get; set; }
    [Required(ErrorMessage = "O campo de Tipo de Consulta é obrigatorio.")]
    public TipoConsulta TipoConsulta { get; set; }
    public Status Status { get; set; }

    public Guid? ConvenioId { get; set; }

    public string? Observacoes { get; set; }

    public List<Guid> ProcedimentoIds { get; set; }
}
