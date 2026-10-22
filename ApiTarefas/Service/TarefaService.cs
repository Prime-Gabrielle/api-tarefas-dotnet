using ApiTarefas.Data;
using ApiTarefas.Models;
using Microsoft.EntityFrameworkCore;

namespace ApiTarefas.Services;

public class TarefaService : ITarefaService
{
    private readonly AppDbContext _context;

    public TarefaService(AppDbContext context)
    {
        _context = context;
    }

    public async Task<List<Tarefa>> ListarTodas()
    {
        return await _context.Tarefas.ToListAsync();
    }

    public async Task<Tarefa?> BuscarPorId(int id)
    {
        return await _context.Tarefas.FindAsync(id);
    }

    public async Task<Tarefa> Criar(Tarefa novaTarefa)
    {
        bool jaExiste = await _context.Tarefas
            .AnyAsync(tarefa => tarefa.Titulo.ToLower() == novaTarefa.Titulo.ToLower());

        if (jaExiste)
        {
            throw new InvalidOperationException("Já existe uma tarefa com o mesmo título.");
        }

        _context.Tarefas.Add(novaTarefa);
        await _context.SaveChangesAsync();

        return novaTarefa;
    }

    public async Task<bool> Atualizar(int id, Tarefa tarefaAtualizada)
    {
        var tarefa = await _context.Tarefas.FindAsync(id);

        if (tarefa == null)
        {
            return false;
        }

        tarefa.Titulo = tarefaAtualizada.Titulo;
        tarefa.Concluida = tarefaAtualizada.Concluida;
        tarefa.Prioridade = tarefaAtualizada.Prioridade;

        await _context.SaveChangesAsync();

        return true;
    }

    public async Task<bool> Deletar(int id)
    {
        var tarefa = await _context.Tarefas.FindAsync(id);

        if (tarefa == null)
        {
            return false;
        }

        _context.Tarefas.Remove(tarefa);
        await _context.SaveChangesAsync();

        return true;
    }
}
