using System;

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

        public int NumeroHabitaciones { get; set; }

        public double TarifaPorNoche { get; set; }

        public double TotalPagar { get; set; }

        public Usuario Usuario { get; set; }
        public Alojamiento Alojamiento { get; set; }
    }

}
