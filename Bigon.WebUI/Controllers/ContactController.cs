using Microsoft.AspNetCore.Mvc;

namespace Bigon.WebUI.Controllers
{
    public class ContactController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
