using ApiTarefas.Data;
using ApiTarefas.DTOs;
using ApiTarefas.Models;
using ApiTarefas.Services;
using Microsoft.AspNetCore.Mvc;     
using Microsoft.EntityFrameworkCore;

namespace ApiTarefas.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    private readonly AppDbContext _context;
    private readonly ITokenService _tokenService; 

    public AuthController(AppDbContext context, ITokenService tokenService)
    {
        _context = context;
        _tokenService = tokenService;
    }

    [HttpPost("registrar")]
    public async Task<IActionResult> Registrar(RegistroDto registroDto)
    {
        bool jaExiste = await _context.Usuarios.AnyAsync(u => u.NomeUsuario == registroDto.Nome);
        if (jaExiste)
        {
            return Conflict (new { message = "Nome de usuário já existe." });
        }

        var usuario = new Usuario
        {
            NomeUsuario = registroDto.Nome,
            SenhaHash = BCrypt.Net.BCrypt.HashPassword(registroDto.Senha),
            Papel = "Usuario"
        };

        _context.Usuarios.Add(usuario);
        await _context.SaveChangesAsync();

        return Ok(new { message = "Usuário registrado com sucesso." });
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login(LoginDto loginDto)
    {
        var usuario = await _context.Usuarios.FirstOrDefaultAsync(u => u.NomeUsuario == loginDto.NomeUsuario);
        if (usuario == null || !BCrypt.Net.BCrypt.Verify(loginDto.Senha, usuario.SenhaHash))
        {
            return Unauthorized(new { message = "Nome de usuário ou senha inválidos." });
        }

        var token = _tokenService.GerarToken(usuario);

        return Ok(new { token });
    }
}

