using Rent_a_car.Models;
using Microsoft.AspNetCore.Mvc;
using Rent_a_car.Repository;

namespace Rent_a_car.Controllers
{
    public class DriverController : Controller
    {
        private readonly IData data;
        public DriverController(IData _data)
        {
            data = _data;
        }
        public IActionResult Index()
        {
            var list = data.GetAllDrivers();
            return View(list);
        }
        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]

        public IActionResult Add(Driver driver)
        {
            if(!ModelState.IsValid)
                return View(driver);
            ViewBag.isSaved = data.AddDriver(driver);
            ModelState.Clear();
            return View();
        }
    }
}
