using Microsoft.AspNetCore.Mvc;
using Fodun.Models.Dtos;
using Fodun.Services.Interfaces;

namespace Fodun.Controllers
{
    public class HomeController : Controller
    {
        private readonly ISedeService _sedeService;

        public HomeController(ISedeService sedeService)
        {
            _sedeService = sedeService;
        }

        public IActionResult Index()
        {
            ViewBag.SedesRecreativas = _sedeService.GetSedesRecreativas();
            ViewBag.Apartamentos = _sedeService.GetApartamentos();

            return View(new DisponibilidadViewModel());
        }
    }
}