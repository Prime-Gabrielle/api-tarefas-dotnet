using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using ApiTarefas.Models;
using Microsoft.IdentityModel.Tokens;

namespace ApiTarefas.Services;

public class TokenService : ITokenService
{
    private readonly IConfiguration _configuration;

    public TokenService(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public string GerarToken(Usuario usuario)
    {
        var chave = _configuration["Jwt:Chave"]!;
        var emissor = _configuration["Jwt:Emissor"];
        var audiencia = _configuration["Jwt:Audiencia"];

        var claims = new[]
        {
            new Claim(JwtRegisteredClaimNames.Sub, usuario.Id.ToString()),
            new Claim(ClaimTypes.Name, usuario.NomeUsuario),
            new Claim(ClaimTypes.Role, usuario.Papel)
        };

        var chaveSimetrica = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(chave));
        var credenciais = new SigningCredentials(chaveSimetrica, SecurityAlgorithms.HmacSha256);

        var token = new  JwtSecurityToken(
            issuer: emissor,
            audience: audiencia,
            claims: claims,
            expires: DateTime.UtcNow.AddHours(1),
            signingCredentials: credenciais);

        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}