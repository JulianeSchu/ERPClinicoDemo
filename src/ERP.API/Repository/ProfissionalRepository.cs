using ERP.API.Domain.Interfaces;
using ERP.API.Models;
using ERP.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace ERP.API.Infrastructure.Repositories;

public class ProfissionalRepository : IProfissionalRepository
{
    private readonly AppDbContext _context;

    public ProfissionalRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<Profissional?> ObterPorIdAsync(Guid id)
    {
        return await _context.Profissionais.FindAsync(id);
    }

    public async Task<IEnumerable<Profissional>> ObterTodosAsync()
    {
        return await _context.Profissionais.ToListAsync();
    }

    public async Task<IEnumerable<Profissional>> BuscarPorNomeAsync(string nome)
    {
        return await _context.Profissionais
            .Where(p => p.NomeCompleto.Contains(nome))
            .ToListAsync();
    }

    public async Task<bool> CpfExisteAsync(string cpf)
    {
        return await _context.Profissionais.AnyAsync(p => p.Cpf == cpf);
    }

    public async Task<bool> CrmExisteAsync(string crm)
    {
        return await _context.Profissionais.AnyAsync(p => p.Crm == crm);
    }

    public async Task AdicionarAsync(Profissional profissional)
    {
        await _context.Profissionais.AddAsync(profissional);
        await _context.SaveChangesAsync();
    }

    public async Task AtualizarAsync(Profissional profissional)
    {
        _context.Profissionais.Update(profissional);
        await _context.SaveChangesAsync();
    }

    public async Task RemoverAsync(Guid id)
    {
        var profissional = await ObterPorIdAsync(id);
        if (profissional != null)
        {
            _context.Profissionais.Remove(profissional);
            await _context.SaveChangesAsync();
        }
    }

    public Task<Profissional?> ObterPorCpfAsync(string cpf)
    {
        throw new NotImplementedException();
    }

    public Task<Profissional?> ObterPorCrmAsync(string crm)
    {
        throw new NotImplementedException();
    }
}
