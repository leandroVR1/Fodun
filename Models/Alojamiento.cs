using System.Collections.Generic;

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
        public ICollection<Disponibilidad> Disponibilidades { get; set; }
        public ICollection<Reserva> Reservas { get; set; }

        
        public ICollection<Tarifa> Tarifas { get; set; }
    }

}
