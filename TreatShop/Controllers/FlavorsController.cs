using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using TreatShop.Models;
using System.Linq;
using Microsoft.AspNetCore.Authorization;

namespace TreatShop.Controllers
{
  [Authorize]
  public class FlavorsController : Controller
  {
    private readonly TreatShopContext _db;

    public FlavorsController(TreatShopContext db)
    {
      _db = db;
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

    [AllowAnonymous]
    public ActionResult Details(int id)
    {
      Flavor thisFlavor = _db.Flavors
                          .Include(flavor => flavor.JoinEntities)
                          .ThenInclude(join => join.Treat)
                          .FirstOrDefault(flavor => flavor.FlavorId == id);
      ViewBag.Treats = _db.Treats
                      .Include(treat => treat.JoinEntities)
                      .ThenInclude(join => join.Flavor)
                      .ToList();
      return View(thisFlavor);
    }

    
    [HttpPost]
    public ActionResult Edit(Flavor flavor)
    {
      _db.Flavors.Update(flavor);
      _db.SaveChanges();
      return RedirectToAction("Details", new { id = flavor.FlavorId });
    }

    [HttpPost]
    public ActionResult Delete(int id)
    {
      Flavor thisFlavor = _db.Flavors.FirstOrDefault(flavor => flavor.FlavorId == id);
      _db.Flavors.Remove(thisFlavor);
      _db.SaveChanges();
      return RedirectToAction("Index", "Home");
    }

    [HttpPost]
    public ActionResult AddTreat(int id, int treatId)
    {
      Flavor flavor = _db.Flavors.FirstOrDefault(flavor => flavor.FlavorId == id);
      
      #nullable enable
      FlavorTreat? joinEntity = _db.FlavorTreats.FirstOrDefault(join => (join.TreatId == treatId && join.FlavorId == flavor.FlavorId));
      #nullable disable

      if (joinEntity == null && treatId != 0)
      {
        _db.FlavorTreats.Add(new FlavorTreat() { TreatId = treatId, FlavorId = flavor.FlavorId });
        _db.SaveChanges();
      }
      return RedirectToAction("Details", new { id = flavor.FlavorId });
    }

    [HttpPost]
    public ActionResult DeleteJoin(int joinId)
    {
      FlavorTreat joinEntry = _db.FlavorTreats.FirstOrDefault(entry => entry.FlavorTreatId == joinId);
      _db.FlavorTreats.Remove(joinEntry);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }



  }
}
