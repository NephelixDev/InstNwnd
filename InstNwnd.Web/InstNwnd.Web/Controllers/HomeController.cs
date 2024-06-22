using InstNwnd.Web.Models; // Asegúrate de tener el namespace correcto para ErrorViewModel si es necesario
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging; // Importa el espacio de nombres adecuado para ILogger
using System.Diagnostics;

namespace InstNwnd.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        // Constructor que recibe ILogger para manejar logging
        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        // Acción para la página principal (Index)
        public IActionResult Index()
        {
            return View(); // Devuelve la vista correspondiente a la acción Index
        }

        // Acción para la página de privacidad (Privacy)
        public IActionResult Privacy()
        {
            return View(); // Devuelve la vista correspondiente a la acción Privacy
        }

        // Acción para manejar errores
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            // Crea una instancia de ErrorViewModel para pasar a la vista de error
            var viewModel = new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier };
            return View(viewModel); // Devuelve la vista de error con el modelo ErrorViewModel
        }
    }
}
