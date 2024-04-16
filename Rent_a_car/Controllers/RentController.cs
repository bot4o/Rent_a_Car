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
            var list = data.GetAllRents();
            return View(list);
        }
        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Add(MakeRentModel rent)//egh egh!!!
        {
            Rent k = new Rent();
            k.DriverId = rent.UserId;
            k.CarId = data.GetCarIdByBrandandModel(rent.Brand, rent.Model);
            k.StartDate = rent.StartDate;
            k.EndDate = rent.EndDate;
            if (!ModelState.IsValid)
                return View(rent);
            ViewBag.IsSaved = data.BookingNow(k);
            ModelState.Clear();
            return View();
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
