namespace ERP.API.Shared.Dtos;

public class ReadProfissionalDto
{
    public string NomeCompleto { get; set; }
    public string CPF { get; set; }
    public string CRM { get; set; } // ou CRO, CREFITO, etc.
    public string Especialidade { get; set; }
    public string Telefone { get; set; }
    public string Email { get; set; }
}
