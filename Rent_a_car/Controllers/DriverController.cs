using Rent_a_car.Models;
using Microsoft.AspNetCore.Mvc;
using Rent_a_car.Repository;
using Microsoft.AspNetCore.Authorization;

namespace Rent_a_car.Controllers
{
    public class DriverController : Controller
    {
        private readonly IData data;
        public DriverController(IData _data)
        {
            data = _data;
        }
        [Authorize(Roles = "Admin")]
        public IActionResult Index()
        {
            var list = data.GetAllDrivers();
            return View(list);
        }
        public IActionResult Add()
        {
            return View();
        }
        public IActionResult Delete(string id)
        {
            bool isDeleted = data.DeleteDriver(id);
            if(isDeleted)
            {
                return RedirectToAction("Index");
            }
            else
            {
                return RedirectToAction("Index");
            }
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
