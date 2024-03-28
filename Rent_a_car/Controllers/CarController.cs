using Microsoft.AspNetCore.Mvc;

namespace Rent_a_car.Controllers
{
    public class CarController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
