using Microsoft.AspNetCore.Mvc;
using Fodun.Services.Interfaces;
using Fodun.Models;

namespace Fodun.Controllers
{
    public class SedeViewController : Controller
    {
        private readonly ISedeService _sedeService;

        public SedeViewController(ISedeService sedeService)
        {
            _sedeService = sedeService;
        }

        public IActionResult Index()
        {
            var sedes = _sedeService.GetSedesRecreativas();
            return View(sedes);
        }

        public IActionResult Details(int id)
        {
            var sede = _sedeService.GetSedeById(id);
            if (sede == null)
            {
                return NotFound();
            }
            return View(sede);
        }
    }
}