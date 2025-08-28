using ERP.API.Domain.Models;
using System.ComponentModel.DataAnnotations;

namespace ERP.API.Shared.Dtos;

public class CreateConvenioDto
{
    [Required]
    public string Nome { get; set; } = string.Empty;
    public string? Cnpj { get; set; }
}
