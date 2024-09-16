using Microsoft.AspNetCore.Mvc;
using Fodun.Services;
using Fodun.Models;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.AspNetCore.Authorization;

namespace Fodun.Controllers
{
   
    public class SedeViewController : Controller
    {
        private readonly ISedeService _sedeService;

        public SedeViewController(ISedeService sedeService)
        {
            _sedeService = sedeService;
        }



        // Acción que muestra la vista para las sedes
        public async Task<IActionResult> Sedes()
        {
            var sedes = await _sedeService.GetSedes();

            if (sedes == null || !sedes.Any())
            {
                // Pasar un modelo vacío o un mensaje a la vista
                ViewBag.Message = "No se encontraron sedes.";
                return View(Enumerable.Empty<Sede>());
            }

            // Retorna la vista con el modelo de sedes
            return View(sedes);
        }
    }
}
