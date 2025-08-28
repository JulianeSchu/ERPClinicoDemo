using ERP.API.Domain.Interfaces;
using ERP.API.Domain.Models;
using ERP.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using ERP.API.Shared.Dtos;


namespace ERP.API.Infrastructure.Repositories;

public class PacienteRepository : IPacienteRepository
{
    private readonly AppDbContext _context;

    public PacienteRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<Paciente> FindAsync(Guid id)
    {
        return await _context.Pacientes
        .Include(p => p.PacienteConvenios) 
            .ThenInclude(pc => pc.Convenio)
        .FirstOrDefaultAsync(p => p.Id == id);
    }

    public async Task<IEnumerable<Paciente>> ToListAsync()
    {
        return await _context.Pacientes
        .Include(p => p.PacienteConvenios)
            .ThenInclude(pc => pc.Convenio)
        .ToListAsync();
    }

    public async Task<IEnumerable<Paciente>> BuscarPorNomeAsync(string nome)
    {
        return await _context.Pacientes
            .Where(p => p.NomeCompleto.Contains(nome))
            .ToListAsync();
    }

    public async Task<Paciente> GetByCpfAsync(string cpf)
    {
        return await _context.Pacientes.FirstOrDefaultAsync(p => p.Cpf == cpf);
    }

    public async Task<bool> CpfExisteAsync(string cpf)
    {
        return await _context.Pacientes.AnyAsync(p => p.Cpf == cpf);
    }

    public async Task AddAsync(Paciente paciente, List<PacienteConvenioDto> convenios)
    {
        foreach (var convenio in convenios)
        {
            paciente.PacienteConvenios.Add(new PacienteConvenio
            {
                PacienteId = paciente.Id,
                ConvenioId = convenio.ConvenioId,
                DataVinculo = convenio.DataVinculo,
                
            });
        }

        await _context.Pacientes.AddAsync(paciente);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(Paciente paciente, List<PacienteConvenioDto> convenios)
    {
        var pacienteExistente = await _context.Pacientes
            .Include(p => p.PacienteConvenios)
            .FirstOrDefaultAsync(p => p.Id == paciente.Id);

        if (pacienteExistente == null)
            throw new Exception("Paciente não encontrado.");

        // Atualiza dados do paciente
        pacienteExistente.NomeCompleto = paciente.NomeCompleto;
        pacienteExistente.DataNascimento = paciente.DataNascimento;
        pacienteExistente.Sexo = paciente.Sexo;
        pacienteExistente.Telefone = paciente.Telefone;

        // Atualiza convênios com nova data
        pacienteExistente.PacienteConvenios.Clear();
        foreach (var convenio in convenios)
        {
            pacienteExistente.PacienteConvenios.Add(new PacienteConvenio
            {
                PacienteId = paciente.Id,
                ConvenioId = convenio.ConvenioId,
                DataVinculo = convenio.DataVinculo
            });
        }

        await _context.SaveChangesAsync();
    }


    public async Task DeleteAsync(Guid id)
    {
        var paciente = await FindAsync(id);
        if (paciente != null)
        {
            _context.Pacientes.Remove(paciente);
            await _context.SaveChangesAsync();
        }
    }
}
