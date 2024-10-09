using System;
using System.Collections.Generic;

namespace Fodun.Models
{
    public class Reserva
    {
        public int Id { get; set; }
        public int UsuarioId { get; set; }
        public Usuario Usuario { get; set; }
        public int AlojamientoId { get; set; }
        public Alojamiento Alojamiento { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }
        public int NumeroPersonas { get; set; }
        public decimal TotalPagar { get; set; }
        public EstadoReserva Estado { get; set; }
        public DateTime FechaReserva { get; set; }
    }

    public enum EstadoReserva
    {
        Pendiente,
        Confirmada,
        Cancelada,
        Pagada
    }
}