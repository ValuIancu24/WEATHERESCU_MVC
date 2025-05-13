using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace weatherescu_test_2.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

     
    }
}