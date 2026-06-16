using Microsoft.AspNetCore.Mvc;

namespace Medias.Server.Controllers
{
    public class CollectionsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
