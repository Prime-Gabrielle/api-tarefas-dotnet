using ApiTarefas.Models;
using ApiTarefas.Services;
using Microsoft.AspNetCore.Mvc;
using ApiTarefas.DTOs;
using Microsoft.AspNetCore.Authorization;

namespace ApiTarefas.Controllers;

[ApiController]
[Route("[controller]")]
[Authorize]
public class TarefasController : ControllerBase
{
    private readonly ITarefaService _service;

    public TarefasController(ITarefaService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<ActionResult<List<Tarefa>>> ListarTodas()
    {
        var tarefas = await _service.ListarTodas();

        return Ok(tarefas);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Tarefa>> BuscarPorId(int id)
    {
        var tarefa = await _service.BuscarPorId(id);

        if (tarefa == null)
        {
            return NotFound();
        }

        return Ok(tarefa);
    }

    [HttpPost]
    public async Task<ActionResult<TarefaResponseDto>> Criar(CriarTarefaDto dto)
    {
        try
        {
            var tarefa = TarefaMapper.ParaEntidade(dto);
            var criada = await _service.Criar(tarefa);
            var response = TarefaMapper.ParaDto(criada);

            return CreatedAtAction(
                nameof(BuscarPorId),
                new { id = response.Id },
                response);
        }
        catch (InvalidOperationException excecao)
        {
            return Conflict(new { mensagem = excecao.Message });
        }
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Atualizar(int id, Tarefa tarefaAtualizada)
    {
        var atualizada = await _service.Atualizar(id, tarefaAtualizada);

        if (!atualizada)
        {
            return NotFound();
        }

        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Deletar(int id)
    {
        var deletada = await _service.Deletar(id);

        if (!deletada)
        {
            return NotFound();
        }

        return NoContent();
    }
}
