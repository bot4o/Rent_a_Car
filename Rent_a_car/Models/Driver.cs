using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
namespace Rent_a_car.Models
{
    public class Driver : IdentityUser
    {
        [Required]
        public string First_Name { get; set;}
        [Required]
        public string Last_Name{ get; set;}
        [Required]
        public string EGN { get; set;}


        public List<Rent> rents { get; set; }
    }
}
