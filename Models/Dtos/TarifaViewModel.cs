using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fodun.Models
{
    public class TarifaViewModel
    {
        public int AlojamientoId { get; set; }
        public string NombreAlojamiento { get; set; }
        public string NombreSede { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }
        public decimal PrecioBase { get; set; }
        public decimal PrecioPersonaAdicional { get; set; }
        public string Temporada { get; set; }
        public int CapacidadMinima { get; set; }
        public int CapacidadMaxima { get; set; }
    }
}