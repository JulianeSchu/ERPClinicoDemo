using ERP.API.Domain.Models;
using ERP.API.Shared.Dtos;

namespace ERP.API.Domain.Interfaces;

public interface IPacienteRepository
{
    Task<Paciente> FindAsync(Guid id);//Retorna um paciente pelo ID
    Task<IEnumerable<Paciente>> ToListAsync();//Retorna todos os pacientes
    Task<IEnumerable<Paciente>> BuscarPorNomeAsync(string nome);//Retorna pacientes com nome parecido
    Task<Paciente> GetByCpfAsync(string cpf);//Retorna paciente com CPF exato

    Task AddAsync(Paciente paciente, List<PacienteConvenioDto> convenios);//Adiciona paciente
    Task UpdateAsync(Paciente paciente, List<PacienteConvenioDto> convenios);//Atualiza paciente
    Task DeleteAsync(Guid id);//Remove paciente

    Task<bool> CpfExisteAsync(string cpf);//Verifica se já existe um paciente com esse CPF (evita duplicidade)
    
}
