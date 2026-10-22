using System.ComponentModel.DataAnnotations;

namespace ApiTarefas.Models;

public class Usuario
{
    public int Id { get; set; }

    [Required]
    public string NomeUsuario {get; set;} = string.Empty;
    public string SenhaHash {get; set;} = string.Empty;
    public string Papel {get; set;} = "Usuario";
}