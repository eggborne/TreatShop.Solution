using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using TreatShop.Models;
using System.Collections.Generic;
using System.Linq;

namespace TreatShop.Controllers
{
  public class FlavorsController : Controller
  {
    private readonly TreatShopContext _db;

    public FlavorsController(TreatShopContext db)
    {
      _db = db;
    }

    public ActionResult Index()
    {
      List<Flavor> model = _db.Flavors.ToList();
      return View(model);
    }

    public ActionResult Create()
    {
      return View();
    }

    [HttpPost]
    public ActionResult Create(Flavor flavor)
    {
      _db.Flavors.Add(flavor);

      _db.SaveChanges();
      return RedirectToAction("Index", "Home");
    }

    public ActionResult Details(int id)
    {
      Flavor thisTreat = _db.Flavors
                        .Include(flavor => flavor.JoinEntities)
                        .ThenInclude(join => join.Treat)
                        .FirstOrDefault(flavor => flavor.FlavorId == id);
      return View(thisTreat);
    }

    public ActionResult Edit(int id)
    {
      Flavor thisTreat = _db.Flavors.FirstOrDefault(flavor => flavor.FlavorId == id);
      return View(thisTreat);
    }

    [HttpPost]
    public ActionResult Edit(Flavor flavor)
    {
      _db.Flavors.Update(flavor);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    [HttpPost]
    public ActionResult Delete(int id)
    {
      Flavor thisFlavor = _db.Flavors.FirstOrDefault(flavor => flavor.FlavorId == id);
      _db.Flavors.Remove(thisFlavor);
      _db.SaveChanges();
      return RedirectToAction("Index", "Home");
    }
  }
}
