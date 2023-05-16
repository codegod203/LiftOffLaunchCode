using Microsoft.AspNetCore.Mvc;

public class DashboardController : Controller
{
    public ActionResult Index()
    {
        return View("~/Views/Dashboard/Index.cshtml");
    }
}

