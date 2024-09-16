using System.Collections.Generic;
using System.Linq;

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
        public ICollection<Tarifa> Tarifas { get; set; } = new List<Tarifa>();

        // Métodos para obtener tarifas según la temporada
public decimal ObtenerTarifaOrdinaria()
{
    return Tarifas.Any(t => t.TipoTemporada == "Ordinaria") ? (decimal)Tarifas.FirstOrDefault(t => t.TipoTemporada == "Ordinaria")?.TarifaPorNoche : 0;
}

public decimal ObtenerTarifaEspecial()
{
    return Tarifas.Any(t => t.TipoTemporada == "Especial") ? (decimal)Tarifas.FirstOrDefault(t => t.TipoTemporada == "Especial")?.TarifaPorNoche : 0;
}



        
        public bool VerificarDisponibilidad(DateTime fechaInicio, DateTime fechaFin)
{
    if (fechaInicio >= fechaFin) return false;
    return !Disponibilidades.Any(d => d.FechaInicio < fechaFin && d.FechaFin > fechaInicio && !d.Disponible);
}

    }
}
