using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Fodun.Models;

namespace Fodun.Services.Interfaces
{
    public interface ITarifaService
    {
        IEnumerable<TarifaViewModel> GetTarifasByAlojamiento(int alojamientoId, DateTime fechaInicio, DateTime fechaFin);
        decimal CalcularTarifaTotal(int alojamientoId, DateTime fechaInicio, DateTime fechaFin, int numeroPersonas);
    }
}