using System;

namespace Fodun.Models
{
        public class Tarifa
    {
        public int Id { get; set; }
        public int AlojamientoId { get; set; }
        public Alojamiento Alojamiento { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }
        public decimal PrecioBase { get; set; }
        public decimal PrecioPersonaAdicional { get; set; }
        public TipoTemporada Temporada { get; set; }
        public int CapacidadMinima { get; set; }
        public int CapacidadMaxima { get; set; }
    }

    public enum TipoTemporada
    {
        Baja,
        Alta,
        EspecialLunesJueves
    }
}
