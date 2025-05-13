using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using weatherescu_test_2.Models;

namespace weatherescu_test_2.Controllers
{
    public class CitiesController : Controller
    {
        private readonly WeatherContext _context;

        // Constructor to inject the context
        public CitiesController(WeatherContext context)
        {
            _context = context;
        }

        // GET: Cities - Display all cities
        public async Task<IActionResult> Index()
        {
            var cities = await _context.Cities
                                       .Include(c => c.Temperature) // Include related data
                                       .Include(c => c.Humidity)
                                       .Include(c => c.Precipitation)
                                       .Include(c => c.Pressure)
                                       .Include(c => c.WeatherCondition)
                                       .ToListAsync(); // Get cities with their related data

            return View(cities); // Pass cities with related data to the view
        }

    }
}
