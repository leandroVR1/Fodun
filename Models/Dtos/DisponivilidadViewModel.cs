using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fodun.Models.Dtos
{
    public class DisponibilidadViewModel
    {
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }
        public int NumeroPersonas { get; set; }
        public List<AlojamientoDisponibleViewModel> AlojamientosDisponibles { get; set; }
    }

    public class AlojamientoDisponibleViewModel
    {
        public int AlojamientoId { get; set; }
        public string NombreAlojamiento { get; set; }
        public string NombreSede { get; set; }
        public int CapacidadMaxima { get; set; }
        public decimal PrecioTotal { get; set; }
        public List<string> Comodidades { get; set; }
    }
}