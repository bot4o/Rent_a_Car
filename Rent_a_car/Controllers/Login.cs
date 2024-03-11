using Microsoft.AspNetCore.Mvc;

namespace Rent_a_car.Controllers
{
    public class Login : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
