using System.ComponentModel.DataAnnotations;

namespace Rent_a_car.Models
{
    public class MakeRentModel
    {
        [Key]
        public int Id { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string UserId { get; set; }
    }
}
