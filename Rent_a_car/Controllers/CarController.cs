using Microsoft.AspNetCore.Mvc;
using Rent_a_car.Models;
using Rent_a_car.Repository;

namespace Rent_a_car.Controllers
{
    public class CarController : Controller
    {
        private readonly IData data;
        public CarController(IData _data)
        {
            data = _data;
        }
        //[Authorize(Rents = "Admin")]
        public IActionResult Index()
        {
            var list = data.GetAllCars();
            return View(list);
        }
        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Add(Car newcar)
        {
            if(!ModelState.IsValid)
                return View(newcar);
            bool isSaved = data.AddNewCar(newcar);
            ViewBag.isSaved = isSaved;
            ModelState.Clear();
            return View();
        }
        public IActionResult Delete(int id)
        {
            bool isDeleted = data.DeleteCar(id);

            // Optionally, you can handle the result of deletion
            if(isDeleted)
            {
                // Deletion successful
                // You can redirect to the index page or return a success message
                return RedirectToAction("Index");
            }
            else
            {
                // Deletion failed
                // You can handle the failure, perhaps show an error message
                // or redirect to an error page
                return RedirectToAction("Index");
            }
        }
    }
}
