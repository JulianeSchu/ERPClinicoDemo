using ERP.API.Domain.Enums;
using ERP.API.Domain.Models;
using System.ComponentModel.DataAnnotations;

namespace ERP.API.Shared.Dtos;

public class ReadPacienteDto
{
    public string NomeCompleto { get; set; }
    public string Cpf { get; set; }
    public DateTime DataNascimento { get; set; }
    public Sexo Sexo { get; set; } // "M", "F", "Outro"
    public string Telefone { get; set; }
    public string Email { get; set; }
    public string Endereco { get; set; }
    public List<ReadPacienteConvenioDto> Convenios { get; set; }

    public string? Observacoes { get; set; } // Alergias, observações clínicas, etc.
}
