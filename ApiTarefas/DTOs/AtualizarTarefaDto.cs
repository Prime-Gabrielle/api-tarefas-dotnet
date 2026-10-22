using System.ComponentModel.DataAnnotations;
using ApiTarefas.Models;

namespace ApiTarefas.DTOs;
public class AtualizarTarefaDto
{
    [Required(ErrorMessage = "O título da tarefa é obrigatóro.")]
    [StringLength(50, MinimumLength = 3, ErrorMessage = "O título da tarefa deve ter entre 3 e 50 caracteres.")]
    public string Titulo { get; set; }

    public bool Concluida { get; set; }

    public Prioridade Prioridade { get; set; }
}