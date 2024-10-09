/*using Microsoft.AspNetCore.Mvc;
using Fodun.Models;
using Fodun.Services;
using Fodun.Data;

using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

public class ReservasController : Controller
{
    private readonly IReservaService _reservaService;
     private readonly ApplicationDbContext _context;


    public ReservasController(ApplicationDbContext context, IReservaService reservaService)
    {
        _reservaService = reservaService;
         _context = context;
    }

    // Vista para crear reserva
// GET: Reservas/Create
   public IActionResult Create()
{
    // Cargar datos para el formulario
    var model = new Reserva
    {
        Alojamientos = _context.Alojamiento.ToList(),
        Tarifas = _context.Tarifas.ToList(),
        Disponibilidades = _context.Disponibilidades.ToList()
    };

    return View(model);
}

[HttpPost]
[ValidateAntiForgeryToken]
public async Task<IActionResult> Create(ReservaViewModel model)
{
    if (ModelState.IsValid)
    {
        // Lógica para guardar la reserva
        _context.Add(new Reserva
        {
            FechaInicio = model.FechaInicio,
            FechaFin = model.FechaFin,
            NumeroPersonas = model.NumeroPersonas,
           
        });

        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }

    // Re-cargar datos si el modelo no es válido
    model.Alojamientos = _context.Alojamiento.ToList();
    model.Tarifas = _context.Tarifas.ToList();
    model.Disponibilidades = _context.Disponibilidades.ToList();
    
    return View(model);
}


public IActionResult CalcularReserva(ReservaViewModel model)
{
    var reserva = model.Reserva;

    // Calcular el número de noches
    reserva.Noches = (model.FechaFin - model.FechaInicio).Days;

    // Calcular el costo de lavandería
    reserva.LavanderiaCosto = model.Lavanderia ? 50m : 0m; // Ejemplo de costo de lavandería

    // Calcular el total a pagar basado en las tarifas
    var tarifaOrdinaria = model.Alojamientos.FirstOrDefault()?.ObtenerTarifaOrdinaria() ?? 0;
    var tarifaEspecial = model.Alojamientos.FirstOrDefault()?.ObtenerTarifaEspecial() ?? 0;

    reserva.TotalPagar = (model.DiasOrdinarios * tarifaOrdinaria) + (model.DiasEspeciales * tarifaEspecial) + reserva.LavanderiaCosto;

    // Actualizar el modelo con los valores calculados
    model.Reserva = reserva;
    model.ValorTotal = reserva.TotalPagar;

    return View(model);
}



    // Vista de mis reservas
    public async Task<IActionResult> MisReservas()
    {
        var reservas = await _reservaService.GetReservas();
        return View(reservas);
    }
}

*/
