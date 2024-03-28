using Microsoft.AspNetCore.Mvc;

namespace Rent_a_car.Controllers
{
    public class DriverController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
