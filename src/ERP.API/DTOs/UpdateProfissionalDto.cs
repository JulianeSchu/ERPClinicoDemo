using System.ComponentModel.DataAnnotations;

namespace ERP.API.Shared.Dtos;

public class UpdateProfissionalDto
{
    [Required]
    public Guid Id { get; set; }
    public string NomeCompleto { get; set; }
    public string Cpf { get; set; }
    public string Crm { get; set; } // ou CRO, CREFITO, etc.
    public string Especialidade { get; set; }
    public string Telefone { get; set; }
    public string Email { get; set; }
}
