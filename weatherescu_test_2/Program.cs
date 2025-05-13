using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using weatherescu_test_2.Models;
using weatherescu_test_2.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// Add DbContext
builder.Services.AddDbContext<WeatherContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("WeatherDb")));

// Add Identity services
builder.Services.AddIdentity<IdentityUser, IdentityRole>(options => {
    // Password settings
    options.Password.RequireDigit = true;
    options.Password.RequireLowercase = true;
    options.Password.RequireUppercase = true;
    options.Password.RequireNonAlphanumeric = true;
    options.Password.RequiredLength = 8;
})
.AddEntityFrameworkStores<WeatherContext>()
.AddDefaultTokenProviders();

// Configure cookie settings
builder.Services.ConfigureApplicationCookie(options => {
    options.LoginPath = "/Account/Login";
    options.LogoutPath = "/Account/Logout";
    options.AccessDeniedPath = "/Account/AccessDenied";
    options.SlidingExpiration = true;
    options.ExpireTimeSpan = TimeSpan.FromDays(7);
});

// Register the Auth Service
builder.Services.AddScoped<IAuthService, AuthService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles(); // Replace app.MapStaticAssets() with this standard method

app.UseRouting();

// Add these two lines in this exact order
app.UseAuthentication(); // Must come before UseAuthorization
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

// Create roles and admin user on application startup
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    try
    {
        var authService = services.GetRequiredService<IAuthService>();
        var userManager = services.GetRequiredService<UserManager<IdentityUser>>();

        // Create roles
        authService.CreateRoleAsync("Admin").Wait();
        authService.CreateRoleAsync("User").Wait();

        // Create an admin user (change email/password as needed)
        string adminEmail = "admin@weatherescu.com";
        string adminPassword = "Admin123!";

        var adminUser = authService.FindByEmailAsync(adminEmail).Result;
        if (adminUser == null)
        {
            // Register the admin user
            var result = authService.RegisterUserAsync(adminEmail, adminPassword).Result;
            if (result.Succeeded)
            {
                // Find the newly created user
                adminUser = authService.FindByEmailAsync(adminEmail).Result;

                // Add to Admin role
                authService.AddUserToRoleAsync(adminUser.Id, "Admin").Wait();
            }
        }
    }
    catch (Exception ex)
    {
        var logger = services.GetRequiredService<ILogger<Program>>();
        logger.LogError(ex, "An error occurred while creating roles and admin user.");
    }
}

app.Run();