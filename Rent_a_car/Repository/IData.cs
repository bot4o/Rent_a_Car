using Rent_a_car.Models;
using System.Collections.Generic;

namespace Rent_a_car.Repository
{
    public interface IData
    {
        bool AddNewCar(Car newcar);
        List<Car> GetAllCars();
        bool AddDriver(Driver newdriver);
        List<Driver> GetAllDrivers();
        bool BookingNow(Rent rent);
        List<Rent> GetAllRents();
        bool DeleteCar(int id);
        bool DeleteDriver(string id);
        bool DeleteRents(int id);

        List<string> GetBrand();
        List<string> GetModel(string brand);

        string GetDriverIdByUsername(string username);
        int GetCarIdByBrandandModel(string brand, string model);
        string GetCurrentUserId(HttpContext httpContext);
    }
}

