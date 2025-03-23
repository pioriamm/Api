using Api.Models;
using Microsoft.EntityFrameworkCore;

namespace Api.Context;


public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    public DbSet<Jornada>? Jornadas { get; set; }
    public DbSet<Motorista>? Motoristas { get; set; }


}





