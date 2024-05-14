using Microsoft.AspNetCore.Mvc;
using SistemaGestionPedidos.Models;
using System.Diagnostics;

namespace SistemaGestionPedidos.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
			if (String.IsNullOrEmpty(HttpContext.Session.GetString("IdUsuarioLogueado")))
			{
				return RedirectToAction("Login", "Usuario");
			}
			else
			{
				return View();
            }
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
