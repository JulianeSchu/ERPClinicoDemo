using ERP.API.Domain.Models;

namespace ERP.API.Domain.Interfaces;

public interface IConvenioRepository
{
    Task<IEnumerable<Convenio>> GetAllAsync();
    Task<Convenio> FindAsync(Guid id);
    Task<IEnumerable<Convenio>> BuscarPorNomeAsync(string nome);
    Task<Convenio> ObterPorCnpjAsync(string cnpj);
    Task<bool> CnpjExisteAsync(string cnpj);
    Task AddAsync(Convenio convenio);
    Task UpdateAsync(Convenio convenio);
    Task DeleteAsync(Convenio convenio);
}
