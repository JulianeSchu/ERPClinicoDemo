using System.ComponentModel.DataAnnotations;

namespace ERP.API.Shared.Dtos;

public class UpdateConvenioDto
{
    [Required]
    public string Nome { get; set; } = string.Empty;
    public string? Cnpj { get; set; }
    public bool Ativo { get; set; }
}
