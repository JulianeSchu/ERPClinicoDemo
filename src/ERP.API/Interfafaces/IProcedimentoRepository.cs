using ERP.API.Domain.Models;

namespace ERP.API.Domain.Interfaces;

public interface IProcedimentoRepository
{
    Task<Procedimento> GetByIdAsync(Guid id);                     // Retorna um procedimento específico
    Task<IEnumerable<Procedimento>> GetByName(string name); //Busca por nome
    Task<IEnumerable<Procedimento>> GetAllAsync();               // Lista todos os procedimentos
    Task<IEnumerable<Procedimento>> GetProceduresByPatientId(Guid pacienteId);   // Procedimentos por paciente
    Task<IEnumerable<Procedimento>> GetProceduresByProfessionalIdAsync(Guid profissionalId); // Procedimentos por profissional

    Task AddAsync(Procedimento procedimento);                  // Adiciona novo procedimento
    Task UpdateAsync(Procedimento procedimento);                  // Atualiza procedimento existente
    Task RemoveAsync(Guid id);
}
