using Microsoft.AspNetCore.Mvc;
using Fodun.Data;
using Fodun.Models;
using System.Linq;

namespace Fodun.Controllers
{
    public class ReservasController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ReservasController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Reservas/Create
        public IActionResult Create()
        {
            ViewData["Alojamientos"] = _context.Alojamiento.ToList();
            ViewData["Usuarios"] = _context.Usuarios.ToList();
            return View();
        }

        // POST: Reservas/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Reserva reserva)
        {
            if (ModelState.IsValid)
            {
                _context.Reservas.Add(reserva);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Alojamientos"] = _context.Alojamiento.ToList();
            ViewData["Usuarios"] = _context.Usuarios.ToList();
            return View(reserva);
        }

        // GET: Reservas
        public IActionResult Index()
        {
            var reservas = _context.Reservas.ToList();
            return View(reservas);
        }
    }
}
