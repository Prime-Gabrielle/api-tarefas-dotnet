using ApiTarefas.Models;

namespace ApiTarefas.Services;

public interface ITarefaService
{
    Task<List<Tarefa>> ListarTodas();
    Task<Tarefa?> BuscarPorId(int id);
    Task<Tarefa> Criar(Tarefa novaTarefa);
    Task<bool> Atualizar(int id, Tarefa tarefaAtualizada);
    Task<bool> Deletar(int id);
}
