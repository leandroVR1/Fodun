using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fodun.Models
{
    public class Reserva
    {
        public int ReservaId { get; set; }
        public int UsuarioId { get; set; }
        public int AlojamientoId { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }
        public int NumeroPersonas { get; set; }
        public Double TotalPagar { get; set; }
        public Usuario Usuario { get; set; }

    }
        
}