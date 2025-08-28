using AutoMapper;
using ERP.API.Domain.Interfaces;
using ERP.API.Domain.Models;
using ERP.API.Shared.Dtos;
using Microsoft.AspNetCore.Mvc;


namespace ERP.API.Controllers;

[ApiController]
[Route("api/procedimento")]
public class ProcedimentoController : ControllerBase
{
    private readonly IProcedimentoRepository _repository;
    private readonly IMapper _mapper;

    public ProcedimentoController(IProcedimentoRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<ReadProcedimentoDto>>> GetAll()
    {
        var procedimento = await _repository.GetAllAsync();
        return Ok(_mapper.Map<IEnumerable<ReadProcedimentoDto>>(procedimento));
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<ReadProcedimentoDto>> GetByIdAsync(Guid id)
    {
        var procedimento = await _repository.GetByIdAsync(id);
        if (procedimento == null) return NotFound();

        var readDto = _mapper.Map<ReadProcedimentoDto>(procedimento);
        return Ok(readDto);
    }

    [HttpGet("busca_por_nome")]
    public async Task<ActionResult<IEnumerable<ReadProcedimentoDto>>> GetByName([FromQuery] string name)
    {
        var procedimento = await _repository.GetByName(name);

        if (!procedimento.Any())
            return NotFound($"Nenhum procedimento {name} encontrado.");

        return Ok(_mapper.Map<IEnumerable<ReadProcedimentoDto>>(procedimento));
    }

    [HttpPost]
    public async Task<ActionResult> AddAsync([FromBody] CreateProcedimentoDto dto)
    {
        var procedimento = _mapper.Map<Procedimento>(dto);
        await _repository.AddAsync(procedimento);

        var location = Url.Action("GetByIdAsync", "Procedimento", new { id = procedimento.Id }, Request.Scheme);
        return Created(location, dto);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult> UpdateAsync(Guid id, [FromBody] UpdateProcedimentoDto dto)
    {
        if (id != dto.Id) return BadRequest("Id da URL e do corpo não coincidem.");
        if (!ModelState.IsValid) return BadRequest(ModelState);

        var procedimento = await _repository.GetByIdAsync(id);
        if (procedimento == null) return NotFound();

        var procedimentoAtualizado = _mapper.Map(dto, procedimento);
        await _repository.UpdateAsync(procedimento);

        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult>Remove(Guid id)
    {
        var procedimento = await _repository.GetByIdAsync(id);
        if (procedimento == null) return NotFound();

        await _repository.RemoveAsync(id);
        return NoContent();
    }
}
