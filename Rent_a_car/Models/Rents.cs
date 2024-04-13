using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Rent_a_car.Models
{
    public class Rent
    {
        [Key]
        public int Id { get; set; }
        [Column(TypeName = "nvarchar(450)")]
        [Required]
        public string DriverId { get; set; }
        [Column(TypeName = "int")]
        [Required]
        public int CarId { get; set; }


        public Driver Driver { get; set; }
        public Car Car { get; set; }


        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
