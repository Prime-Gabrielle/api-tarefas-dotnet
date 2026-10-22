using ApiTarefas.Models;

namespace ApiTarefas.Services;

public interface ITokenService
{
    string GerarToken(Usuario usuario);
}