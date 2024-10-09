using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Fodun.Models;
using Fodun.Models.Dtos;

namespace Fodun.Services.Interfaces
{
    public interface IReservaService
    {
        IEnumerable<AlojamientoDisponibleViewModel> BuscarDisponibilidad(DateTime fechaInicio, DateTime fechaFin, int numeroPersonas);
        Reserva CrearReserva(ReservaViewModel reservaViewModel, int usuarioId);
        IEnumerable<Reserva> GetReservasByUsuario(int usuarioId);
    }
}