using System;
using System.Collections.Generic;

namespace Fodun.Models
{
    public class Habitacion
    {
        public int Id { get; set; }
        public int AlojamientoId { get; set; }
        public Alojamiento Alojamiento { get; set; }
        public string Nombre { get; set; }
        public int CamasDobles { get; set; }
        public int CamasSencillas { get; set; }
        public int Camarotes { get; set; }
        public bool TieneBanioPrivado { get; set; }
        public int CapacidadMaxima { get; set; }
    }
}