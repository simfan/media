using Microsoft.AspNetCore.Mvc;

namespace Medias.Server.Controllers
{
    public class SearchController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
