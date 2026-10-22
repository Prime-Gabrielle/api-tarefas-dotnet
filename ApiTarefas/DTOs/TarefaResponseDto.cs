using ApiTarefas.Models;

namespace ApiTarefas.DTOs;
public class TarefaResponseDto
{
    public int Id {get; set;}
    public string Titulo { get; set; }
    public bool Concluida {get; set; }
    public Prioridade Prioridade { get; set; }
    public DateTime DataCriacao { get; set; }
    public string Resumo { get; set; }
}