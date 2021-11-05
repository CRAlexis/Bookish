using Microsoft.AspNetCore.Mvc;

namespace Bookish.Controllers
{
    public class ReportsController : Controller
    {
        [HttpGet("/reports")]
        public IActionResult Reports()
        {
            return View();
        }
    }
}