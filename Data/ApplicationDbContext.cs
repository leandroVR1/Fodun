using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Fodun.Models;
using Microsoft.AspNetCore.Identity;

namespace Fodun.Data
{
    public class ApplicationDbContext : IdentityDbContext<IdentityUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Reserva> Reservas { get; set; }
        public DbSet<Sede> Sedes { get; set; }
        public DbSet<Tarifa> Tarifas { get; set; }
        public DbSet<Disponibilidad> Disponibilidades { get; set; }
        public DbSet<Alojamiento> Alojamiento { get; set; }
        public DbSet<Imagen> Imagenes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Disponibilidad>()
                .HasOne(d => d.Alojamiento)
                .WithMany(a => a.Disponibilidades)
                .HasForeignKey(d => d.AlojamientoId);

            modelBuilder.Entity<Reserva>()
                .HasOne(r => r.Alojamiento)
                .WithMany(a => a.Reservas)
                .HasForeignKey(r => r.AlojamientoId);

            modelBuilder.Entity<Reserva>()
                .HasOne(r => r.Usuario)
                .WithMany(u => u.Reservas)
                .HasForeignKey(r => r.UsuarioId);

            modelBuilder.Entity<Alojamiento>()
                .HasOne(a => a.Sede)
                .WithMany(s => s.Alojamientos)
                .HasForeignKey(a => a.SedeId);

            modelBuilder.Entity<Tarifa>()
                .HasOne(t => t.Sede)
                .WithMany(s => s.Tarifas)
                .HasForeignKey(t => t.SedeId);

            modelBuilder.Entity<Tarifa>()
                .HasOne(t => t.Alojamiento)
                .WithMany(a => a.Tarifas)
                .HasForeignKey(t => t.AlojamientoId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Reserva>()
                .Property(r => r.LavanderiaCosto)
                .HasColumnType("decimal(18,2)");

            modelBuilder.Entity<Reserva>()
                .Property(r => r.TarifaPorNoche)
                .HasColumnType("decimal(18,2)");

            modelBuilder.Entity<Reserva>()
                .Property(r => r.TotalPagar)
                .HasColumnType("decimal(18,2)");
        }
    }
}
