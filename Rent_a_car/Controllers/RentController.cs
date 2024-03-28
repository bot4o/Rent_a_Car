using Microsoft.AspNetCore.Mvc;

namespace Rent_a_car.Controllers
{
    public class RentController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
