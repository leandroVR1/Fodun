using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fodun.Models
{
    public class Alojamiento
    {
        public int AlojamientoId { get; set; }
        public int SedeId { get; set; }
        public string TipoAlojamiento { get; set; }
        public int CapacidadMaxima { get; set; }
        public int NumeroHabitaciones { get; set; }
        public string Descripcion { get; set; }
        public Sede Sede { get; set; }
        
    }
}