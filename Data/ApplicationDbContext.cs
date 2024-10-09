using Microsoft.EntityFrameworkCore;
using Fodun.Models;

namespace Fodun.Data
{
    public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : DbContext(options)
    {
        public DbSet<Sede> Sedes { get; set; }
        public DbSet<Alojamiento> Alojamientos { get; set; }
        public DbSet<Habitacion> Habitaciones { get; set; }
        public DbSet<Comodidad> Comodidades { get; set; }
        public DbSet<Servicio> Servicios { get; set; }
        public DbSet<Tarifa> Tarifas { get; set; }
        public DbSet<Reserva> Reservas { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Sede>()
                .HasMany(s => s.Alojamientos)
                .WithOne(a => a.Sede)
                .HasForeignKey(a => a.SedeId);

            modelBuilder.Entity<Alojamiento>()
                .HasMany(a => a.Habitaciones)
                .WithOne(h => h.Alojamiento)
                .HasForeignKey(h => h.AlojamientoId);

            modelBuilder.Entity<Alojamiento>()
                .HasMany(a => a.Comodidades)
                .WithMany();

            modelBuilder.Entity<Alojamiento>()
                .HasMany(a => a.Tarifas)
                .WithOne(t => t.Alojamiento)
                .HasForeignKey(t => t.AlojamientoId);

            modelBuilder.Entity<Sede>()
                .HasMany(s => s.Servicios)
                .WithMany();

            modelBuilder.Entity<Usuario>()
                .HasMany(u => u.Reservas)
                .WithOne(r => r.Usuario)
                .HasForeignKey(r => r.UsuarioId);

            modelBuilder.Entity<Reserva>()
            .HasOne(r => r.Alojamiento)
            .WithMany(a => a.Reservas)
            .HasForeignKey(r => r.AlojamientoId);

        }
    }
}