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
    public class TarifaService : ITarifaService
    {
        private readonly ApplicationDbContext _context;

        public TarifaService(ApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<TarifaViewModel> GetTarifasByAlojamiento(int alojamientoId, DateTime fechaInicio, DateTime fechaFin)
        {
            return _context.Tarifas
                .Include(t => t.Alojamiento)
                .ThenInclude(a => a.Sede)
                .Where(t => t.AlojamientoId == alojamientoId &&
                            t.FechaInicio <= fechaFin &&
                            t.FechaFin >= fechaInicio)
                .Select(t => new TarifaViewModel
                {
                    AlojamientoId = t.AlojamientoId,
                    NombreAlojamiento = t.Alojamiento.Nombre,
                    NombreSede = t.Alojamiento.Sede.Nombre,
                    FechaInicio = t.FechaInicio,
                    FechaFin = t.FechaFin,
                    PrecioBase = t.PrecioBase,
                    PrecioPersonaAdicional = t.PrecioPersonaAdicional,
                    Temporada = t.Temporada.ToString()
                })
                .ToList();
        }

        public decimal CalcularTarifaTotal(int alojamientoId, DateTime fechaInicio, DateTime fechaFin, int numeroPersonas)
        {
            var tarifas = GetTarifasByAlojamiento(alojamientoId, fechaInicio, fechaFin);
            decimal total = 0;

            foreach (var tarifa in tarifas)
            {
                var diasEnTarifa = (tarifa.FechaFin - tarifa.FechaInicio).Days + 1;
                total += tarifa.PrecioBase * diasEnTarifa;

                if (numeroPersonas > tarifa.CapacidadMinima)
                {
                    total += (numeroPersonas - tarifa.CapacidadMinima) * tarifa.PrecioPersonaAdicional * diasEnTarifa;
                }
            }

            return total;
        }
    }
}