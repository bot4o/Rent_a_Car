using System.ComponentModel.DataAnnotations;
namespace Rent_a_car.Models
{
    public class Driver
    {
        public int Id { get; set; }
        [Required]
        public string Username { get; set;}
        [Required]
        public string Password { get; set;}
        [Required]
        public string First_Name { get; set;}
        [Required]
        public string Last_Name{ get; set;}
        [Required]
        public string EGN { get; set;}
        [Required]
        public string Phone { get; set;}
        [Required]
        public string Email { get; set;}
    }
}
