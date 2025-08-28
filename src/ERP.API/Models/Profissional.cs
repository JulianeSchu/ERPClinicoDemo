using ERP.API.Domain.Models;
using System.ComponentModel.DataAnnotations;

namespace ERP.API.Models;

public class Profissional
{
    [Key]
    [Required]
    public Guid Id { get; set; }
    [Required(ErrorMessage = "O campo Nome é obrigatório")]
    public string NomeCompleto { get; set; }
    [Required(ErrorMessage = "O campo CPF é obrigatório e deve conter 11 dígitos")]
    public string Cpf { get; set; }
    [Required]
    public string Crm { get; set; } // ou CRO, CREFITO, etc.
    [Required]
    public string Especialidade { get; set; }
    public string Telefone { get; set; }
    public string Email { get; set; }
    public ICollection<Agendamento> Agendamentos { get; set; }
   
}
