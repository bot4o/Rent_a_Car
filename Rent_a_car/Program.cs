using Rent_a_car.Repository;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MyApplication.Data;
using Microsoft.AspNetCore.Identity.UI.V4.Pages.Account.Internal;
using Rent_a_car.Models;
using Microsoft.AspNetCore.Authentication;
namespace Rent_a_car;

public class Program
{
    public static async Task Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        var connectionString = builder.Configuration.GetConnectionString("ApplicationDbContextConnection") ?? throw new InvalidOperationException("Connection string 'ApplicationDbContextConnection' not found.");

        builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(connectionString));

        builder.Services.AddDefaultIdentity<Driver>(options =>{
            options.SignIn.RequireConfirmedAccount = false;
            options.Password.RequireUppercase = false;
            options.Password.RequireLowercase = false;
            options.Password.RequiredUniqueChars = -1;
            })//true

            .AddRoles<IdentityRole>()
            .AddEntityFrameworkStores<ApplicationDbContext>()
            .AddDefaultTokenProviders();

        builder.Services.Configure<AuthenticationOptions>(options =>
        {
            options.DefaultAuthenticateScheme = null;
            options.DefaultChallengeScheme = null;
            options.DefaultSignInScheme = null;
        });

        builder.Services.AddScoped<Data>();
        builder.Services.AddControllers();
        // Add services to the container.
        builder.Services.AddControllersWithViews();

        builder.Services.AddRazorPages();
        
        builder.Services.AddTransient(typeof(IData), typeof(Data));

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (!app.Environment.IsDevelopment())
        {
            app.UseExceptionHandler("/Home/Error");
            // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
            app.UseHsts();
        }

        app.UseHttpsRedirection();
        app.UseStaticFiles();

        app.UseRouting();

        app.UseAuthorization();

        app.UseEndpoints(endpoints =>
        {
            endpoints.MapRazorPages();
        });

        app.MapControllerRoute(
            name: "default",
            pattern: "{controller=Home}/{action=Index}/{id?}");

        using (var scope = app.Services.CreateScope())
        {
            var roleManager =
                scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();

            var roles = new[] { "Admin", "User" };

            foreach (var role in roles)
            {
                if (!await roleManager.RoleExistsAsync(role))
                    await roleManager.CreateAsync(new IdentityRole(role));
            }
        }

        //        using (var scope = app.Services.CreateScope())
        //        {
        //            var userManager =
        //                scope.ServiceProvider.GetRequiredService<UserManager<Driver>>();

        //            string email = "admin@admin.com";
        //            string password = "Test1234,";


        //            if (await userManager.FindByEmailAsync(email) == null)
        //            {
        //                var user = new Driver();
        //                user.UserName = email;
        //                user.Email = email;
        ////                user.EmailConfirmed = true;

        //                await userManager.CreateAsync(user, password);

        //                await userManager.AddToRoleAsync(user, "Admin");
        //            }

        //        }

        app.Run();
    }
}
