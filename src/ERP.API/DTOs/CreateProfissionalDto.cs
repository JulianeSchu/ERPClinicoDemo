using System.ComponentModel.DataAnnotations;

namespace ERP.API.Shared.Dtos;

public class CreateProfissionalDto
{
    [Required(ErrorMessage = "O campo Nome é obrigatório")]
    public string NomeCompleto { get; set; }
    [Required(ErrorMessage = "O campo CPF é obrigatório e deve conter 11 dígitos")]
    public string Cpf { get; set; }
    [Required]
    public string Crm { get; set; } // ou CRO, CREFITO, etc.
    [Required]
    public string Especialidade { get; set; }
    [Required]
    public string Telefone { get; set; }
    [Required]
    public string Email { get; set; }
}
