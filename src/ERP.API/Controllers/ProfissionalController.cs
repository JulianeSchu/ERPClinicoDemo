using AutoMapper;
using ERP.API.Domain.Interfaces;
using ERP.API.Infrastructure.Repositories;
using ERP.API.Models;
using ERP.API.Shared.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace ERP.API.Controllers;

[ApiController]
[Route("api/profissional")]
public class ProfissionalController : ControllerBase
{
    private readonly IProfissionalRepository _profissionalRepository;
    private readonly IMapper _mapper;
    private readonly ICpfUnicoService _cpfUnicoService;

    public ProfissionalController(IProfissionalRepository profissionalRepository, IMapper mapper, ICpfUnicoService cpfUnicoService)
    {
        _profissionalRepository = profissionalRepository;
        _mapper = mapper;
        _cpfUnicoService = cpfUnicoService;
    }

    //GET: api/profissional
    [HttpGet]
    public async Task<ActionResult<IEnumerable<ReadProfissionalDto>>> ObterTodos()
    {
        var profissionais = await _profissionalRepository.ObterTodosAsync();
        var profissionaisDto = _mapper.Map<IEnumerable<ReadProfissionalDto>>(profissionais);
        return Ok(profissionaisDto);
    }

    //GET: api/profissional/{id}
    [HttpGet("{id}")]
    public async Task<ActionResult<ReadProfissionalDto>> ObterPorId(Guid id)
    {
        var profissional = await _profissionalRepository.ObterPorIdAsync(id);
        if (profissional == null) return NotFound();

        return Ok(_mapper.Map<ReadProfissionalDto>(profissional));
    }

    // POST: api/profissional
    [HttpPost]
    public async Task<ActionResult> Adicionar([FromBody] CreateProfissionalDto dto)
    {
        if (!ModelState.IsValid) return BadRequest(ModelState);

        if (await _cpfUnicoService.CpfExisteAsync(dto.Cpf))
            return Conflict("CPF já existente.");
        if (await _profissionalRepository.CrmExisteAsync(dto.Crm))
            return Conflict("Já existe um profissional com esse CRM.");

        var profissional = _mapper.Map<Profissional>(dto);
        await _profissionalRepository.AdicionarAsync(profissional);

        return CreatedAtAction(nameof(ObterPorId), new { id = profissional.Id }, _mapper.Map<ReadProfissionalDto>(profissional));
    }

    // PUT: api/profissional/{id}
    [HttpPut("{id}")]
    public async Task<ActionResult> Atualizar(Guid id, [FromBody] UpdateProfissionalDto dto)
    {
        if (id != dto.Id) return BadRequest("ID da URL e do corpo não coincidem.");
        if (!ModelState.IsValid) return BadRequest(ModelState);
       

        var profissionalExistente = await _profissionalRepository.ObterPorIdAsync(id);
        if (profissionalExistente == null) return NotFound();

        var profissionalAtualizado = _mapper.Map(dto, profissionalExistente);
        await _profissionalRepository.AtualizarAsync(profissionalAtualizado);

        return NoContent();
    }

    // DELETE: api/profissional/{id}
    [HttpDelete("{id}")]
    public async Task<ActionResult> Remover(Guid id)
    {
        var profissional = await _profissionalRepository.ObterPorIdAsync(id);
        if (profissional == null) return NotFound();

        await _profissionalRepository.RemoverAsync(id);
        return NoContent();
    }
}
