using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Rent_a_car.Models;
using Rent_a_car.Repository;
using Microsoft.AspNetCore.Identity;
using Humanizer;

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
            if (User.IsInRole("Admin"))
            {
                var list = data.GetAllRents();
                return View(list);
            }
            else
            {
                return(View());
            }
        }
        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Add(MakeRentModel rent)//egh egh!!!
        {
            rent.UserId = data.GetCurrentUserId(HttpContext);

            Rent k = new Rent();
            k.DriverId = rent.UserId; //invallid
            k.CarId = data.GetCarIdByBrandandModel(rent.Brand, rent.Model);
            k.StartDate = rent.StartDate;
            k.EndDate = rent.EndDate; //UserId for some reason is invalid
            if (!ModelState.IsValid)
                return View(rent);
            ViewBag.IsSaved = data.BookingNow(k);
            ModelState.Clear();
            return View();
        }
        public IActionResult Delete(int id)
        {
            bool isDeleted = data.DeleteRents(id);

            if(isDeleted)
            {
                return RedirectToAction("Index");
            }
            else
            {
                return RedirectToAction("Index");
            }
        }
        [HttpGet]
        public IActionResult GetBrand()
        {
            var list = data.GetBrand();
            return Json(list);
        }
        [HttpGet]
        public IActionResult GetModel(string brand)
        {
            var list = data.GetModel(brand);
            return Json(list);
        }
        public IActionResult GetDriver()
        {
            var list = data.GetAllDrivers();
            return Json(list);
        }
    }
}
