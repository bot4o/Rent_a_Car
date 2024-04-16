using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Rent_a_car.Models;

namespace MyApplication.Data;

public class ApplicationDbContext : IdentityDbContext<Driver>
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public DbSet<Driver> Drivers { get; set; }
    public DbSet<Car> Cars { get; set; }
    public DbSet<Rent> Rents { get; set; }
    public DbSet<IdentityRole> Roles { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        /*builder.Entity<Rent>()
            .HasOne(c => c.Car)
            .WithMany(r => r.rents)
            .HasForeignKey(c => c.CarId);
        builder.Entity<Rent>()
            .HasOne(u => u.Driver)
            .WithMany(r => r.rents)
            .HasForeignKey(u => u.DriverId);*/
    }
}
