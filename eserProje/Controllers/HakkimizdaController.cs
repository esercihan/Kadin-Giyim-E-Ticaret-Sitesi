using Microsoft.AspNetCore.Mvc;

namespace eserProje.Controllers
{
    public class HakkimizdaController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
