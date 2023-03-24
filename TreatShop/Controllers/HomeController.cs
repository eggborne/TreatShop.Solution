using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using TreatShop.Models;

namespace TreatShop.Controllers
{
    public class HomeController : Controller
    {
      private readonly TreatShopContext _db;

      public HomeController(TreatShopContext db)
      {
        _db = db;
      }

      [HttpGet("/")]
      public ActionResult Index()
      {
        ViewBag.Treats = _db.Treats
                      .Include(treat => treat.JoinEntities)
                      .ThenInclude(join => join.Flavor)
                      .ToList();
        ViewBag.Flavors = _db.Flavors
                      .Include(flavor => flavor.JoinEntities)
                      .ThenInclude(join => join.Treat)
                      .ToList();
        return View();
      }
    }
}