using System.ComponentModel.DataAnnotations;

namespace ApiTarefas.Models;

public class Tarefa
{
    public int Id { get; set; }
    
    [Required(ErrorMessage = "O titulo da tarefa é obrigatório.")]
    [StringLength(50, MinimumLength = 3, ErrorMessage = "O titulo da tarefa deve ter entre 3 e 50 caracteres.")]
    public string Titulo {get; set;} = string.Empty;
    public bool Concluida {get; set; }

    public Prioridade Prioridade {get; set;} = Prioridade.Media;
    public DateTime DataCriacao {get; set;} = DateTime.Now;
    public string Resumo => $"[{Prioridade}] {Titulo} - {(Concluida ? "Concluída" : "Pendente")}";
}