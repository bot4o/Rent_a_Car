﻿using Microsoft.AspNetCore.Mvc;
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

            if(isDeleted)
            {
                return RedirectToAction("Index");
            }
            else
            {
                return RedirectToAction("Index");
            }
        }
    }
}
