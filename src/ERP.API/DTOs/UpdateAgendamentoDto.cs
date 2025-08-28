using ERP.API.Domain.Models;
using ERP.API.Models;
using System.ComponentModel.DataAnnotations;

namespace ERP.API.Shared.Dtos;

public class UpdateAgendamentoDto
{
    [Required(ErrorMessage = "O campo de Profisional é obrigatorio.")]
    public Profissional Profissional { get; set; }
    [Required(ErrorMessage = "O campo de Procedimento é obrigatorio.")]
    public DateTime DataHoraInicio { get; set; }
    [Required(ErrorMessage = "O campo de Data/Hora de Fim é obrigatorio.")]
    public DateTime DataHoraFim { get; set; }
    public string? Observacoes { get; set; }
}
