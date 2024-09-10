using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Fodun.Models;

namespace Fodun.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext (DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public DbSet<Usuario> Usuarios { get; set; }

    public DbSet<Reserva> Reservas { get; set; }

    public DbSet<Sede> Sedes { get; set; }

    public DbSet<Tarifa> Tarifas { get; set; }

    public DbSet<Disponivilidad> Disponivilidades { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
{
    modelBuilder.Entity<Disponivilidad>()
        .HasOne(d => d.Alojamiento)
        .WithMany() 
        .HasForeignKey(d => d.AlojamientoId);


        

    
}

}
