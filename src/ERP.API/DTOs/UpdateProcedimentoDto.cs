using ERP.API.Domain.Models;
using System.ComponentModel.DataAnnotations;

namespace ERP.API.Shared.Dtos;

public class UpdateProcedimentoDto
{
    [Required]
    public Guid Id { get; set; }
    public string Nome { get; set; }                    // Nome do procedimento (ex: "Raio-X")
    public string? Descricao { get; set; }              // Opcional: descrição detalhada

    public decimal Preco { get; set; }                  // Valor do procedimento
    public TimeSpan? DuracaoEstimada { get; set; }      // Ex: 00:30:00 para 30 minutos
}
