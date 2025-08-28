using ERP.API.Domain.Enums;
using System.ComponentModel.DataAnnotations;

namespace ERP.API.Domain.Models;

public class Paciente
{
    [Key]
    [Required]
    public Guid Id { get; set; }
    [Required(ErrorMessage = "O campo Nome é obrigatório")]
    public string NomeCompleto { get; set; }
    [Required(ErrorMessage = "O campo CPF é obrigatório e deve conter 11 dígitos")]
    public string Cpf { get; set; }
    [Required]
    public DateTime DataNascimento { get; set; }
    public Sexo Sexo { get; set; } // "M", "F", "Outro"
    [Required]
    public string Telefone { get; set; }
    [Required]
    public string Email { get; set; }
    [Required]
    public string Endereco { get; set; }

    public string? Observacoes { get; set; } // Alergias, observações clínicas, etc.
    public ICollection<Agendamento> Agendamentos { get; set; } = new List<Agendamento>();
    public ICollection<PacienteConvenio> PacienteConvenios { get; set; } = new List<PacienteConvenio>();

}
