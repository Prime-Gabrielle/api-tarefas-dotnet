using System.ComponentModel.DataAnnotations;

namespace ApiTarefas.DTOs;

public class RegistroDto
{
    [Required]
    public string Nome { get; set; } = string.Empty;

    [Required]
    [MinLength(6, ErrorMessage = "A senha deve ter no minimo 6 caracteres.")]
    public string Senha {get; set; } = string.Empty;
}