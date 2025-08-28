using ERP.API.Domain.Models;

namespace ERP.API.Domain.Interfaces;

public interface IAgendamentoRepository
{
    Task<Agendamento?> FindAsync(Guid id); //Buscar um agendamento específico
    Task<IEnumerable<Agendamento>> GetAllAsync();//Obter todos os agendamentos
    Task<IEnumerable<Agendamento>> GetByDateAsync(DateTime data); //Obter todos os agendamentos por data
    Task<IEnumerable<Agendamento>> ObterPorPacienteIdAsync(Guid pacienteId);//Obter todos por pacientes
    Task<IEnumerable<Agendamento>> ObterPorProfissionalIdAsync(Guid profissionalId);//Obter todos por profissional

    Task AddAsync(Agendamento agendamento);//Adicionar agendamento
    Task UpDateAsync(Agendamento agendamento);//Atualizar agendamento
    Task RemoveAsync(Guid id); //Remover agendamento

    Task<bool> ExisteAgendamentoNoHorarioAsync(Guid profissionalId, DateTime horario);//Verifica se já existe agendamento naquele horário para evitar conflitos
    Task<IEnumerable<Agendamento>> FindByPeriod(DateTime dataInicio, DateTime dataFim);
}
