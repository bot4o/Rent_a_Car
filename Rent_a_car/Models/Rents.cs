using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Rent_a_car.Models
{
    public class Rent
    {
        [Key]
        public int Id { get; set; }

        //problem
        [Column(TypeName = "nvarchar(450)")]
        [Required]
        public string DriverId { get; set; }

        [NotMapped]
        public Driver Driver { get; set; }

        [Column(TypeName = "int")]
        [Required]
        public int CarId { get; set;}
        [NotMapped]
        public Car Car { get; set; }
        [Required]
        public DateTime StartDate { get; set; }
        [Required]
        public DateTime EndDate { get; set; }
        
        // //problem
        // [NotMapped] // Exclude from database
        // public Car Car { get; set; }

        // //problem
        // [NotMapped] // Exclude from database
        // public Driver Driver { get; set;}
    }
}
