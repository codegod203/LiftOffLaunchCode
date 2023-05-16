using Microsoft.AspNetCore.Mvc;

namespace Moonwalkers.Controllers
{
    public class CalendarController : Controller
    {
        public IActionResult Index()
        {
            return View("~/Views/Calendar/Index.cshtml");
        }
    }
}
