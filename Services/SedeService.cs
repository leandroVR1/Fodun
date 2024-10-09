using System.Collections.Generic;
using System.Linq;
using Fodun.Data;
using Fodun.Models;
using Fodun.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Fodun.Services
{
    public class SedeService : ISedeService
    {
        private readonly ApplicationDbContext _context;

        public SedeService(ApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Sede> GetSedesRecreativas()
        {
            return _context.Sedes
                .Where(s => s.TipoSede == TipoSede.SedeRecreativa)
                .Include(s => s.Alojamientos)
                .ToList();
        }

        public IEnumerable<Sede> GetApartamentos()
        {
            return _context.Sedes
                .Where(s => s.TipoSede == TipoSede.Apartamento)
                .Include(s => s.Alojamientos)
                .ToList();
        }

        public Sede GetSedeById(int id)
        {
            return _context.Sedes
                .Include(s => s.Alojamientos)
                .Include(s => s.Servicios)
                .FirstOrDefault(s => s.Id == id);
        }
    }
}