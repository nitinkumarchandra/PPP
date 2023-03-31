using Microsoft.AspNetCore.Mvc;

namespace NitinPortal.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
