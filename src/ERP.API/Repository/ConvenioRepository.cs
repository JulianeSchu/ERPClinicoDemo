using ERP.API.Domain.Interfaces;
using ERP.API.Domain.Models;
using ERP.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace ERP.API.Infrastructure.Repositories;

public class ConvenioRepository : IConvenioRepository
{
    private readonly AppDbContext _context;

    public ConvenioRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<Convenio> FindAsync(Guid id)
    {
        return await _context.Convenios.FindAsync(id);
    }

    public async Task<IEnumerable<Convenio>> GetAllAsync()
    {
        return await _context.Convenios.ToListAsync();
    }

    public async Task<IEnumerable<Convenio>> BuscarPorNomeAsync(string nome)
    {
        return await _context.Convenios
            .Where(c => c.Nome.Contains(nome))
            .ToListAsync();
    }

    public async Task<Convenio> ObterPorCnpjAsync(string cnpj)
    {
        return await _context.Convenios
            .FirstOrDefaultAsync(c => c.Cnpj == cnpj);
    }

    public async Task<bool> CnpjExisteAsync(string cnpj)
    {
        return await _context.Convenios
            .AnyAsync(c => c.Cnpj == cnpj);
    }

    public async Task AddAsync(Convenio convenio)
    {
        await _context.Convenios.AddAsync(convenio);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(Convenio convenio)
    {
        _context.Convenios.Update(convenio);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(Convenio convenio)
    {
        _context.Convenios.Remove(convenio);
        await _context.SaveChangesAsync();
    }
}
