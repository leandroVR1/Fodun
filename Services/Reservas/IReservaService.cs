using System.Collections.Generic;
using System.Threading.Tasks;
using Fodun.Models;

public interface IReservaService
{
    Task<List<Alojamiento>> GetAlojamientos();
    Task<bool> ValidarFechas(Reserva reserva);
    Task<bool> ConsultarDisponibilidad(Reserva reserva);
    Task<decimal> CalcularCostoTotal(Reserva reserva);
    Task CrearReserva(Reserva reserva);
    Task<List<Reserva>> GetReservas();
}
