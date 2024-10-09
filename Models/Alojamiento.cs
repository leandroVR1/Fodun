using System;
using System.Collections.Generic;

namespace Fodun.Models
{
    public class Alojamiento
    {
        public int Id { get; set; }
        public int SedeId { get; set; }
        public Sede Sede { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public int CapacidadMaxima { get; set; }
        public List<Habitacion> Habitaciones { get; set; }
        public List<Comodidad> Comodidades { get; set; }
        public List<Tarifa> Tarifas { get; set; }
        public List<Reserva> Reservas { get; set; }
    }
}