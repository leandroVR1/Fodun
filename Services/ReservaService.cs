using System;
using System.Collections.Generic;
using System.Linq;
using Fodun.Data;
using Fodun.Models;
using Fodun.Models.Dtos;
using Fodun.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Fodun.Services
{
    public class ReservaService : IReservaService
    {
        private readonly ApplicationDbContext _context;
        private readonly ITarifaService _tarifaService;

        public ReservaService(ApplicationDbContext context, ITarifaService tarifaService)
        {
            _context = context;
            _tarifaService = tarifaService;
        }

        public IEnumerable<AlojamientoDisponibleViewModel> BuscarDisponibilidad(DateTime fechaInicio, DateTime fechaFin, int numeroPersonas)
        {
            var alojamientosDisponibles = _context.Alojamientos
                .Include(a => a.Sede)
                .Include(a => a.Comodidades)
                .Where(a => a.CapacidadMaxima >= numeroPersonas &&
                            !a.Reservas.Any(r => 
                                (r.FechaInicio <= fechaFin && r.FechaFin >= fechaInicio) &&
                                r.Estado != EstadoReserva.Cancelada))
                .ToList();

            return alojamientosDisponibles.Select(a => new AlojamientoDisponibleViewModel
            {
                AlojamientoId = a.Id,
                NombreAlojamiento = a.Nombre,
                NombreSede = a.Sede.Nombre,
                CapacidadMaxima = a.CapacidadMaxima,
                PrecioTotal = _tarifaService.CalcularTarifaTotal(a.Id, fechaInicio, fechaFin, numeroPersonas),
                Comodidades = a.Comodidades.Select(c => c.Nombre).ToList()
            });
        }

        public Reserva CrearReserva(ReservaViewModel reservaViewModel, int usuarioId)
        {
            var reserva = new Reserva
            {
                UsuarioId = usuarioId,
                AlojamientoId = reservaViewModel.AlojamientoId,
                FechaInicio = reservaViewModel.FechaInicio,
                FechaFin = reservaViewModel.FechaFin,
                NumeroPersonas = reservaViewModel.NumeroPersonas,
                TotalPagar = reservaViewModel.TotalPagar,
                Estado = EstadoReserva.Pendiente,
                FechaReserva = DateTime.Now
            };

            _context.Reservas.Add(reserva);
            _context.SaveChanges();

            return reserva;
        }

        public IEnumerable<Reserva> GetReservasByUsuario(int usuarioId)
        {
            return _context.Reservas
                .Include(r => r.Alojamiento)
                .ThenInclude(a => a.Sede)
                .Where(r => r.UsuarioId == usuarioId)
                .OrderByDescending(r => r.FechaReserva)
                .ToList();
        }
    }
}