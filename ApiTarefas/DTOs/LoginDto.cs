using System.ComponentModel.DataAnnotations;

namespace ApiTarefas.DTOs;

public class LoginDto
{
    [Required]
    public string NomeUsuario{get; set; } = string.Empty;

    [Required]
    public string Senha {get; set; } = string.Empty;
}
