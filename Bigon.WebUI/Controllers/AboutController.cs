using Microsoft.AspNetCore.Mvc;

namespace Bigon.WebUI.Controllers
{
    public class AboutController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
