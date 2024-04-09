using System.ComponentModel.DataAnnotations;
namespace Rent_a_car.Models
{
    public class Rent
    {
        public int Id { get; set; }
        [Required]
        public int Selected_car { get; set; }
        [Required]
        public DateTime Start_date { get; set; }
        [Required]
        public DateTime End_date { get; set; }
        [Required]
        public int Driver { get; set; }
    }
}
