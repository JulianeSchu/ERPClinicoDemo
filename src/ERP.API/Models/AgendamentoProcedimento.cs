using ERP.API.Models;
using System.ComponentModel.DataAnnotations;

namespace ERP.API.Domain.Models;

public class AgendamentoProcedimento
{
    [Required]
    public Guid AgendamentoId { get; set; }
    public Agendamento Agendamento { get; set; }
    [Required]
    public Guid ProcedimentoId { get; set; }
    public Procedimento Procedimento { get; set; }

}
