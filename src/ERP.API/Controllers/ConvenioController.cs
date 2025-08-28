using AutoMapper;
using ERP.API.Domain.Interfaces;
using ERP.API.Domain.Models;
using ERP.API.Shared.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace ERP.API.Controllers;

[ApiController]
[Route("api/convenio")]
public class ConvenioController : ControllerBase
{
    private readonly IConvenioRepository _repository;
    private readonly IMapper _mapper;

    public ConvenioController(IConvenioRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<ReadConvenioDto>>> GetAll()
    {
        var convenios = await _repository.GetAllAsync();
        var dtos = _mapper.Map<IEnumerable<ReadConvenioDto>>(convenios);
        return Ok(dtos);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<ReadConvenioDto>> GetById(Guid id)
    {
        var convenio = await _repository.FindAsync(id);
        if (convenio == null) return NotFound();

        var dto = _mapper.Map<ReadConvenioDto>(convenio);
        return Ok(dto);
    }

    //api/convenio/buscar-por-nome?nome=
    [HttpGet("buscar-por-nome")]
    public async Task<ActionResult<IEnumerable<ReadConvenioDto>>> BuscarPorNome([FromQuery] string nome)
    {
        if (string.IsNullOrWhiteSpace(nome))
            return BadRequest("O parâmetro 'nome' é obrigatório.");

        var convenios = await _repository.BuscarPorNomeAsync(nome);
        var dtos = _mapper.Map<IEnumerable<ReadConvenioDto>>(convenios);
        return Ok(dtos);
    }

    //api/convenio/buscar-por-cnpj?cnpj=
    [HttpGet("buscar-por-cnpj")]
    public async Task<ActionResult<ReadConvenioDto>> BuscarPorCnpj([FromQuery] string cnpj)
    {
        if (string.IsNullOrWhiteSpace(cnpj))
            return BadRequest("O parâmetro 'cnpj' é obrigatório.");

        var convenio = await _repository.ObterPorCnpjAsync(cnpj);
        if (convenio == null)
            return NotFound();

        var dto = _mapper.Map<ReadConvenioDto>(convenio);
        return Ok(dto);
    }

    [HttpPost]
    public async Task<ActionResult> Create([FromBody] CreateConvenioDto dto)
    {
        var convenio = _mapper.Map<Convenio>(dto);

        await _repository.AddAsync(convenio);

        var readDto = _mapper.Map<ReadConvenioDto>(convenio);
        return CreatedAtAction(nameof(GetById), new { id = convenio.Id }, readDto);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(Guid id, [FromBody] UpdateConvenioDto dto)
    {
        var convenio = await _repository.FindAsync(id);
        if (convenio == null) return NotFound();

        _mapper.Map(dto, convenio);

        await _repository.UpdateAsync(convenio);

        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        var convenio = await _repository.FindAsync(id);
        if (convenio == null) return NotFound();

        await _repository.DeleteAsync(convenio);

        return NoContent();
    }
}
