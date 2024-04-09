using Microsoft.AspNetCore.Mvc;
using Rent_a_car.Models;
using Rent_a_car.Repository;

namespace Rent_a_car.Controllers
{
    public class RentController : Controller
    {
        private readonly IData data;
        public RentController(IData data)
        {
            this.data = data;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Add(Rent rent)
        {
            if(!ModelState.IsValid)
                return View(rent);
            ViewBag.IsSaved = data.BookingNow(rent);
            ModelState.Clear();
            return View();
        }
        [HttpGet]
        public IActionResult GetBrand()
        {
            var list = data.GetBrand();
            return Json(list);
        }
    }
}
