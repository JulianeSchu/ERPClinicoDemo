namespace ERP.API.Domain.Interfaces;

public interface ICpfUnicoService
{
    Task<bool> CpfExisteAsync(string cpf);
}
