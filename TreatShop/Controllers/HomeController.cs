using Microsoft.AspNetCore.Mvc;

using TreatShop.Models;

namespace TreatShop.Controllers
{
    public class HomeController : Controller
    {

      [HttpGet("/")]
      public ActionResult Index()
      {
        return View();
      }

      [HttpPost()]
      public ActionResult Index(ApplicationUser applicationUser)
      {
        return View();
      }

    }
}