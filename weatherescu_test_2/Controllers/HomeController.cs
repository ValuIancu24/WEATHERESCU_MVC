using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using weatherescu_test_2.Models;

namespace weatherescu_test_2.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly WeatherContext _context;

        public HomeController(ILogger<HomeController> logger, WeatherContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

      

        public async Task<IActionResult> Humidity()
        {
            var humidities = await _context.Cities
                .Include(c => c.Humidity)
                .ToListAsync();

            return View(humidities);
        }

        public async Task<IActionResult> Precipitation()
        {
            var precipitations = await _context.Cities
                .Include(c => c.Precipitation)
                .ToListAsync();

            return View(precipitations);
        }

        public async Task<IActionResult> Temperature()
        {
            var temperatures = await _context.Cities
                .Include(c => c.Temperature)
                .ToListAsync();

            return View(temperatures);
        }

        public IActionResult Contact()
        {
            return View();
        }

        public IActionResult About()
        {
            return View();
        }

        

        public async Task<IActionResult> Cities()
        {
            var cities = await _context.Cities.ToListAsync(); // Get cities from the database
            return View(cities); // Pass cities to the view
        }




        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
