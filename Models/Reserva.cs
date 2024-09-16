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
        
        public int Noches { get; set; }


        public int NumeroPersonas { get; set; }
        public int NumeroHabitaciones { get; set; }

        public bool Lavanderia { get; set; }  
        public decimal TarifaPorNoche { get; set; }  
        public decimal LavanderiaCosto { get; set; }  
        public decimal TotalPagar { get; set; }

        public Usuario Usuario { get; set; }
        public Alojamiento Alojamiento { get; set; }  

        // Propiedades adicionales para la vista
        public int DiasOrdinarios { get; set; }
        public int DiasEspeciales { get; set; }

        // Relación con la sede
        public Sede Sede => Alojamiento?.Sede;  

        // Cálculo del valor total
        public decimal ValorTotal => TotalPagar + (DiasOrdinarios * TarifaPorNoche);
    }
}
