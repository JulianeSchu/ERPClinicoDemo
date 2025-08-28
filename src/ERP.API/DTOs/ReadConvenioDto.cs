using System.ComponentModel.DataAnnotations;

namespace ERP.API.Shared.Dtos;

public class ReadConvenioDto
{
    public string Nome { get; set; } = string.Empty;
    public string? Cnpj { get; set; }
    public bool Ativo { get; set; }
}
