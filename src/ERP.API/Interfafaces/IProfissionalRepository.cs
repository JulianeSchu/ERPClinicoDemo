using ERP.API.Models;

namespace ERP.API.Domain.Interfaces;

public interface IProfissionalRepository
{
    Task<IEnumerable<Profissional>> ObterTodosAsync();
    Task<Profissional?> ObterPorIdAsync(Guid id);
    Task<Profissional?> ObterPorCpfAsync(string cpf);
    Task<Profissional?> ObterPorCrmAsync(string crm);
    Task<bool> CpfExisteAsync(string cpf);
    Task<bool> CrmExisteAsync(string crm);
    Task AdicionarAsync(Profissional profissional);
    Task AtualizarAsync(Profissional profissional);
    Task RemoverAsync(Guid id);
}
