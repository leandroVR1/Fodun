namespace Fodun.Models
{
    public class ReservaViewModel
    {
        public List<Alojamiento> Alojamientos { get; set; }
        public List<Tarifa> Tarifas { get; set; }
        public List<Disponibilidad> Disponibilidades { get; set; }
        public Reserva Reserva { get; set; }

        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }
        public int Noches { get; set; }
        public int NumeroPersonas { get; set; }
        public bool Lavanderia { get; set; }
        public int NumeroHabitaciones { get; set; }
        public int DiasOrdinarios { get; set; }
        public int DiasEspeciales { get; set; }
        public decimal LavanderiaCosto { get; set; }
        public decimal ValorTotal { get; set; }
        public Sede Sede { get; set; }
    }
}
