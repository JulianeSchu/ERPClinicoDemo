using ERP.API.Domain.Interfaces;
using ERP.API.Domain.Models;
using ERP.API.Models;
using ERP.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;


namespace ERP.API.Infrastructure.Repositories;

public class ProcedimentoRepository : IProcedimentoRepository
    {
        private readonly AppDbContext _context;

        public ProcedimentoRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Procedimento> GetByIdAsync(Guid id)
        {
            return await _context.Procedimentos
                .FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<IEnumerable<Procedimento>> GetAllAsync()
        {
            return await _context.Procedimentos
                .Include(p => p.AgendamentosProcedimentos)
                .ToListAsync();
        }

        public async Task<IEnumerable<Procedimento>> GetProceduresByPatientId(Guid pacienteId)
        {
        return await _context.Agendamentos
            .Where(a => a.PacienteId == pacienteId)
            .Include(a => a.AgendamentosProcedimentos)
            .ThenInclude(ap => ap.Procedimento)
            .SelectMany(a => a.AgendamentosProcedimentos.Select(ap => ap.Procedimento))
            .Distinct()
            .ToListAsync();
    }

        public async Task<IEnumerable<Procedimento>> GetProceduresByProfessionalIdAsync(Guid profissionalId)
        {
        return await _context.Agendamentos
            .Where(a => a.PacienteId == profissionalId)
            .Include(a => a.AgendamentosProcedimentos)
            .ThenInclude(ap => ap.Procedimento)
            .SelectMany(a => a.AgendamentosProcedimentos.Select(ap => ap.Procedimento))
            .Distinct()
            .ToListAsync();
    }

        public async Task AddAsync(Procedimento procedimento)
        {
            await _context.Procedimentos.AddAsync(procedimento);
            await _context.SaveChangesAsync();
        }

    public async Task UpdateAsync(Procedimento procedimento)
    {
        _context.Procedimentos.Update(procedimento);
        await _context.SaveChangesAsync();
    }

    public async Task RemoveAsync(Guid id)
        {
            var procedimento = await GetByIdAsync(id);
            if (procedimento != null)
            {
                _context.Procedimentos.Remove(procedimento);
                await _context.SaveChangesAsync();
            }
        }

    public async Task<IEnumerable<Procedimento>> GetByName(string name)
    {
        return await _context.Procedimentos
        .Where(p => p.Nome.Contains(name))
        .ToListAsync();
    }
}
