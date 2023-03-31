using Microsoft.AspNetCore.Mvc;
using System.Security;
using System.Security.Cryptography.X509Certificates;

namespace NitinPortal.Controllers
{
    public class RegistrationController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
    public IActionResult Index(string FirstName, string LastName, string Email, string CompanyName, string Country, string State, string City)
        {


            TempData["FirstName"] = FirstName;
            TempData["LastName"] = LastName;
            TempData["Email"] = Email;
            TempData["CompanyName"] = CompanyName;
            TempData["Country"] = Country;
            TempData["State"] = State;
            TempData["City"] = City;


            return View();
        }
    }
}
