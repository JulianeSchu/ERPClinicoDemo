using AutoMapper;
using ERP.API.Domain.Interfaces;
using ERP.API.Domain.Models;
using ERP.API.Shared.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace ERP.API.Controllers;

[ApiController]
[Route("api/paciente")]
public class PacientesController : ControllerBase
{
    private readonly IPacienteRepository _pacienteRepository;
    private readonly IMapper _mapper;
    private readonly ICpfUnicoService _cpfUnicoService;

    public PacientesController(IPacienteRepository pacienteRepository, IMapper mapper, ICpfUnicoService cpfUnicoService)
    {
        _pacienteRepository = pacienteRepository;
        _mapper = mapper;
        _cpfUnicoService = cpfUnicoService;
    }

    //GET: api/pacientes
    [HttpGet]
    public async Task<ActionResult<IEnumerable<ReadPacienteDto>>> GetAll()
    {
        var pacientes = await _pacienteRepository.ToListAsync();
        var pacientesDto = _mapper.Map<IEnumerable<ReadPacienteDto>>(pacientes);
        return Ok(pacientesDto);
    }

    //GET: api/pacientes/{id}
    [HttpGet("{id}")]
    public async Task<ActionResult<ReadPacienteDto>> GetById(Guid id)
    {
        var paciente = await _pacienteRepository.FindAsync(id);
        if (paciente == null) return NotFound();

        return Ok(_mapper.Map<ReadPacienteDto>(paciente));
    }

    // POST: api/pacientes
    [HttpPost]
    public async Task<ActionResult> Create([FromBody] CreatePacienteDto dto)
    {
        if (!ModelState.IsValid) return BadRequest(ModelState);

        if (await _cpfUnicoService.CpfExisteAsync(dto.Cpf))
            return Conflict("CPF já existente.");

        var paciente = _mapper.Map<Paciente>(dto);
        await _pacienteRepository.AddAsync(paciente, dto.Convenios);

        return CreatedAtAction(nameof(GetAll), new { id = paciente.Id }, _mapper.Map<ReadPacienteDto>(paciente));
    }

    // PUT: api/pacientes/{id}
    [HttpPut("{id}")]
    public async Task<ActionResult> Update(Guid id, [FromBody] UpdatePacienteDto dto)
    {
        if (id != dto.Id) return BadRequest("ID da URL e do corpo não coincidem.");
        if (!ModelState.IsValid) return BadRequest(ModelState);
        

        var pacienteExistente = await _pacienteRepository.FindAsync(id);
        if (pacienteExistente == null) return NotFound();

        var pacienteAtualizado = _mapper.Map(dto, pacienteExistente);
        await _pacienteRepository.UpdateAsync(pacienteAtualizado, dto.Convenios);

        return NoContent();
    }

    // DELETE: api/pacientes/{id}
    [HttpDelete("{id}")]
    public async Task<ActionResult> Delete(Guid id)
    {
        var paciente = await _pacienteRepository.FindAsync(id);
        if (paciente == null) return NotFound();

        await _pacienteRepository.DeleteAsync(id);
        return NoContent();
    }
}
