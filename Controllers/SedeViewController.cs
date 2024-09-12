using Microsoft.AspNetCore.Mvc;
using Fodun.Services;

namespace Fodun.Controllers
{
    public class SedeViewController : Controller
    {
        private readonly ISedeService _sedeService;

        public SedeViewController(ISedeService sedeService)
        {
            _sedeService = sedeService;
        }

        public async Task<IActionResult> Sedes()
        {
            var sedes = await _sedeService.GetSedes();

            if (sedes == null || !sedes.Any())
            {
                return Content("No se encontraron sedes.");
            }

            return View(sedes);
        }
    }
}