using Fodun.Data;
using Fodun.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

public class ReservaService : IReservaService
{
    private readonly ApplicationDbContext _context;

    public ReservaService(ApplicationDbContext context)
    {
        _context = context;
    }

    // Validar fechas de reserva
    public async Task<bool> ValidarFechas(Reserva reserva)
    {
        return reserva.FechaInicio < reserva.FechaFin;
    }

    // Consultar disponibilidad de alojamiento
    public async Task<bool> ConsultarDisponibilidad(Reserva reserva)
    {
        return await _context.Disponibilidades
            .Where(d => d.AlojamientoId == reserva.AlojamientoId &&
                        d.FechaInicio >= reserva.FechaInicio && d.FechaFin <= reserva.FechaFin)
            .AllAsync(d => d.Disponible);
    }

    // Calcular días ordinarios
public async Task<int> CalcularDiasOrdinarios(DateTime fechaInicio, DateTime fechaFin)
{
    // Supongamos que los días ordinarios son de lunes a viernes
    int diasOrdinarios = 0;
    for (var date = fechaInicio; date <= fechaFin; date = date.AddDays(1))
    {
        if (date.DayOfWeek != DayOfWeek.Saturday && date.DayOfWeek != DayOfWeek.Sunday)
        {
            diasOrdinarios++;
        }
    }
    return diasOrdinarios;
}

// Calcular días especiales
public async Task<int> CalcularDiasEspeciales(DateTime fechaInicio, DateTime fechaFin)
{
    
    int diasEspeciales = 0;
    for (var date = fechaInicio; date <= fechaFin; date = date.AddDays(1))
    {
        if (date.DayOfWeek == DayOfWeek.Saturday || date.DayOfWeek == DayOfWeek.Sunday)
        {
            diasEspeciales++;
        }
    }
    return diasEspeciales;
}


    // Calcular el costo total de la reserva
    public async Task<decimal> CalcularCostoTotal(Reserva reserva)
{
    // Calcular número de días ordinarios y especiales
    int diasOrdinarios = await CalcularDiasOrdinarios(reserva.FechaInicio, reserva.FechaFin);
    int diasEspeciales = await CalcularDiasEspeciales(reserva.FechaInicio, reserva.FechaFin);

    // Obtener tarifas
    var tarifaOrdinaria = reserva.Alojamiento.ObtenerTarifaOrdinaria();
    var tarifaEspecial = reserva.Alojamiento.ObtenerTarifaEspecial();

    // Calcular total
    decimal total = (diasOrdinarios * tarifaOrdinaria) + (diasEspeciales * tarifaEspecial);

    // Costos adicionales, lavandería
    if (reserva.Lavanderia)
    {
        total += 50; 
    }

    return total;
}


    // Crear reserva
    public async Task CrearReserva(Reserva reserva)
    {
        _context.Reservas.Add(reserva);
        await _context.SaveChangesAsync();
    }

    // Obtener alojamientos
    public async Task<List<Alojamiento>> GetAlojamientos()
    {
        return await _context.Alojamiento.ToListAsync();
    }

    // Obtener reservas
    public async Task<List<Reserva>> GetReservas()
    {
        return await _context.Reservas
            .Include(r => r.Alojamiento)
            .Include(r => r.Usuario)
            .ToListAsync();
    }
}



