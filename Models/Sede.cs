using System.Collections.Generic;

namespace Fodun.Models
{
    public class Sede
    {
        public int SedeId { get; set; }
        public string Nombre { get; set; }
        public string Tipo { get; set; }
        public int CapacidadTotal { get; set; }
        public string Ubicacion { get; set; }
        public string Descripcion { get; set; }

        public ICollection<Alojamiento> Alojamientos { get; set; }
        public ICollection<Tarifa> Tarifas { get; set; }
    }
}
