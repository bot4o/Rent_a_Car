using System.ComponentModel.DataAnnotations;
namespace Rent_a_car.Models
{
    public class Car
    {
        public int Id { get; set; }
        [Required]
        public string? Brand { get; set; }
        [Required]
        public string? Model{ get; set; }
        [Required]
        public int Year { get; set; }
        [Required]
        public int Seats { get; set; }
        [Required]
        public string? Description { get; set; }
        [Required]
        public double Price { get; set; }
    }
}
