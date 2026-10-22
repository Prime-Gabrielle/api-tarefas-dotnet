using ApiTarefas.Models;
using Microsoft.EntityFrameworkCore;

namespace ApiTarefas.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    public DbSet<Tarefa> Tarefas { get; set; }
    public DbSet<Usuario> Usuarios { get; set; }
}
