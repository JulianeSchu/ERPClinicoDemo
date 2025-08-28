using AutoMapper;
using ERP.API.Domain.Interfaces;
using ERP.API.Domain.Models;
using ERP.API.Shared.Dtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace ERP.API.Controllers;

[ApiController]
[Route("api/agendamento")]
public class AgendamentoController : ControllerBase
{
    private readonly IAgendamentoRepository _repository;
    private readonly IMapper _mapper;

    public AgendamentoController(IAgendamentoRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<ReadAgendamentoDto>>> GetAll()
    {
        var agendamento = await _repository.GetAllAsync();
        return Ok(_mapper.Map<IEnumerable<ReadAgendamentoDto>>(agendamento));
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<ReadAgendamentoDto>> GetById(Guid id)
    {
        var agendamento = await _repository.FindAsync(id);
        if (agendamento == null) return NotFound();
        return Ok(_mapper.Map<ReadAgendamentoDto>(agendamento));
    }

    [HttpGet("{por-data}")]
    public async Task<ActionResult<IEnumerable<ReadAgendamentoDto>>> GetByDate(
        [FromQuery] DateTime dataInicio,
        [FromQuery] DateTime dataFim
        )
    {
        if (dataInicio > dataFim)
            return BadRequest("A data inicial não pode ser maior que a data final.");
        
        var agendamento = await _repository.FindByPeriod(dataInicio, dataFim);

        if (!agendamento.Any())
            return NotFound("Nenhum agendamento encontrado nesse período.");

        return Ok(_mapper.Map<IEnumerable<ReadAgendamentoDto>>(agendamento));
    }

    [HttpPost]
    public async Task<ActionResult> Create([FromBody] CreateAgendamentoDto dto)
    {
        var agendamento = _mapper.Map<Agendamento>(dto);

        foreach (var procedimentoId in dto.ProcedimentoIds)
        {
            agendamento.AgendamentosProcedimentos.Add(new AgendamentoProcedimento
            {
                ProcedimentoId = procedimentoId
                // AgendamentoId é opcional aqui; será atribuído automaticamente pelo EF se a navegação estiver correta
            });
        }

        await _repository.AddAsync(agendamento);

        var agendamentoCompleto = await _repository.FindAsync(agendamento.Id);
        if (agendamentoCompleto == null) return NotFound();

        var readDto = _mapper.Map<ReadAgendamentoDto>(agendamentoCompleto);
        return CreatedAtAction(nameof(GetById), new { id = agendamento.Id }, readDto);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(Guid id, [FromBody] UpdateAgendamentoDto dto)
    {
        var agendamento = await _repository.FindAsync(id);
        if (agendamento == null) return NotFound();

        _mapper.Map(dto, agendamento);
        await _repository.UpDateAsync(agendamento);

        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        var agendamento = await _repository.FindAsync(id);
        if (agendamento == null) return NotFound();

        await _repository.RemoveAsync(agendamento.Id);
        return NoContent();
    }
}
