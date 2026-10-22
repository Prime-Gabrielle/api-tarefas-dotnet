using ApiTarefas.Models;
using ApiTarefas.DTOs;

namespace ApiTarefas.DTOs;

public static  class TarefaMapper
{
    public static Tarefa ParaEntidade(CriarTarefaDto dto)
    {
        return new Tarefa
        {
            Titulo = dto.Titulo,
            Prioridade = dto.Prioridade,
            Concluida = false,
            DataCriacao = DateTime.Now
        };
    }

    public static TarefaResponseDto ParaDto(Tarefa tarefa)
    {
        return new TarefaResponseDto
        {
            Id = tarefa.Id,
            Titulo = tarefa.Titulo,
            Concluida = tarefa.Concluida, 
            Prioridade = tarefa.Prioridade,
            DataCriacao = tarefa.DataCriacao,
            Resumo = tarefa.Resumo
        };
    }
}