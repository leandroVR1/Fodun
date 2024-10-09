using System;
using System.Collections.Generic;

namespace Fodun.Models
{
    public class Sede
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Ubicacion { get; set; }
        public int CapacidadTotal { get; set; }
        public List<Alojamiento> Alojamientos { get; set; }
        public List<Servicio> Servicios { get; set; }
        public string Descripcion { get; set; }
        public TipoSede TipoSede { get; set; }
    }

    public enum TipoSede
    {
        SedeRecreativa,
        Apartamento
    }
}