using Rent_a_car.Models;

namespace Rent_a_car.Repository
{
    public interface IData
    {
        bool AddNewCar(Car newcar);
        List<Car> GetAllCars();
        bool AddDriver(Driver newdriver);
        List<Driver> GetAllDrivers();
        bool BookingNow(Rent rent);

        List<string> GetBrand();
    }
}
