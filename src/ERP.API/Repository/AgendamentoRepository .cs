using ERP.API.Domain.Interfaces;
using ERP.API.Domain.Models;
using ERP.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace ERP.API.Infrastructure.Repositories;

public class AgendamentoRepository : IAgendamentoRepository
{
    private readonly AppDbContext _context;

    public AgendamentoRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<Agendamento?> FindAsync(Guid id)
    {
        return await _context.Agendamentos
            .Include(a => a.Paciente)
            .Include(a => a.Profissional)
            .Include(a => a.Convenios)
            .Include(a => a.AgendamentosProcedimentos)
            .ThenInclude(ap => ap.Procedimento)
            .FirstOrDefaultAsync(a => a.Id == id);
    }

    public async Task<IEnumerable<Agendamento>> GetAllAsync()
    {
        return await _context.Agendamentos
            .Include(a => a.Paciente)
            .Include(a => a.Profissional)
            .Include(a => a.Convenios)
            .Include(a => a.AgendamentosProcedimentos)
            .ThenInclude(ap => ap.Procedimento)
            .ToListAsync();
    }

    public async Task<IEnumerable<Agendamento>> ObterPorPacienteIdAsync(Guid pacienteId)
    {
        return await _context.Agendamentos
            .Where(a => a.PacienteId == pacienteId)
            .ToListAsync();
    }

    public async Task<IEnumerable<Agendamento>> ObterPorProfissionalIdAsync(Guid profissionalId)
    {
        return await _context.Agendamentos
            .Where(a => a.ProfissionalId == profissionalId)
            .ToListAsync();
    }

    public async Task<IEnumerable<Agendamento>> GetByDateAsync(DateTime data)
    {
        return await _context.Agendamentos
            .Where(a => a.DataHoraInicio.Date == data.Date)
            .ToListAsync();
    }

    public async Task AddAsync(Agendamento agendamento)
    {
        await _context.Agendamentos.AddAsync(agendamento);
        await _context.SaveChangesAsync();
    }

    public async Task UpDateAsync(Agendamento agendamento)
    {
        _context.Agendamentos.Update(agendamento);
        await _context.SaveChangesAsync();
    }

    public async Task RemoveAsync(Guid id)
    {
        var agendamento = await FindAsync(id);
        if (agendamento != null)
        {
            _context.Agendamentos.Remove(agendamento);
            await _context.SaveChangesAsync();
        }
    }

    public async Task<IEnumerable<Agendamento>> FindByPeriod(DateTime dataInicio, DateTime dataFim)
    {
        return await _context.Agendamentos
            .Include(a => a.Paciente)
            .Include(a => a.Profissional)
            .Include(a => a.Convenios)
            .Where(a => a.DataHoraInicio >= dataInicio.Date &&
                        a.DataHoraInicio <= dataFim.Date)
            .ToListAsync();
    }

    public async Task<bool> ExisteAgendamentoNoHorarioAsync(Guid profissionalId, DateTime horario)
    {
        return await _context.Agendamentos.AnyAsync(a =>
            a.ProfissionalId == profissionalId &&
            a.DataHoraInicio <= horario &&
            a.DataHoraFim >= horario);
    }

}
