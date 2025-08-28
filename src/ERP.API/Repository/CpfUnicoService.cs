using ERP.API.Domain.Interfaces;

namespace ERP.API.Infrastructure.Repositories;

public class CpfUnicoService : ICpfUnicoService
{
    private readonly IPacienteRepository _pacienteRepository;
    private readonly IProfissionalRepository _profissionalRepository;

    public CpfUnicoService(IPacienteRepository pacienteRepository, IProfissionalRepository profissionalRepository)
    {
        _pacienteRepository = pacienteRepository;
        _profissionalRepository = profissionalRepository;
    }

    public async Task<bool> CpfExisteAsync(string cpf)
    {
        var existeNoPaciente = await _pacienteRepository.CpfExisteAsync(cpf);
        var existeNoProfissional = await _profissionalRepository.CpfExisteAsync(cpf);

        return existeNoPaciente || existeNoProfissional;
    }
}
