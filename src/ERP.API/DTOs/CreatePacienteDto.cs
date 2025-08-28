using ERP.API.Domain.Enums;
using ERP.API.Domain.Models;
using ERP.API.Models;
using System.ComponentModel.DataAnnotations;

namespace ERP.API.Shared.Dtos;

public class CreatePacienteDto
{
    [Required(ErrorMessage = "O campo Nome Completo é obrigatório")]
    public string NomeCompleto { get; set; }
    [Required(ErrorMessage = "O campo CPF é obrigatório e deve conter 11 dígitos")]
    public string Cpf { get; set; }
    [Required]
    public DateTime DataNascimento { get; set; }
    [Required]
    public Sexo Sexo { get; set; } // "M", "F", "Outro"
    [Required]
    public string Telefone { get; set; }
    [Required]
    public string Email { get; set; }
    [Required]
    public string Endereco { get; set; }
    public List<PacienteConvenioDto> Convenios { get; set; }

    public string? Observacoes { get; set; } // Alergias, observações clínicas, etc.
}
