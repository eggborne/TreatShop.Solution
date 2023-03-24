using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using TreatShop.Models;
using System.Linq;
using Microsoft.AspNetCore.Authorization;

namespace TreatShop.Controllers
{
  [Authorize]
  public class TreatsController : Controller
  {
    private readonly TreatShopContext _db;

    public TreatsController(TreatShopContext db)
    {
      _db = db;
    }

    public ActionResult Create()
    {
      return View();
    }

    [HttpPost]
    public ActionResult Create(Treat treat, int flavorId)
    {
      _db.Treats.Add(treat);
      _db.SaveChanges();

      AddFlavor(treat.TreatId, flavorId);

      return RedirectToAction("Index", "Home");
    }

    [AllowAnonymous]
    public ActionResult Details(int id)
    {
      Treat thisTreat = _db.Treats
                        .Include(treat => treat.JoinEntities)
                        .ThenInclude(join => join.Flavor)
                        .FirstOrDefault(treat => treat.TreatId == id);
      ViewBag.Flavors = _db.Flavors
                        .Include(flavor => flavor.JoinEntities)
                        .ThenInclude(join => join.Treat)
                        .ToList();
      return View(thisTreat);
    }

    public ActionResult Edit(int id)
    {
      Treat thisTreat = _db.Treats.FirstOrDefault(treat => treat.TreatId == id);
      return View(thisTreat);
    }

    [HttpPost]
    public ActionResult Edit(Treat treat)
    {
      _db.Treats.Update(treat);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    [HttpPost]
    public ActionResult Delete(int id)
    {
      Treat thisTreat = _db.Treats.FirstOrDefault(treat => treat.TreatId == id);
      _db.Treats.Remove(thisTreat);
      _db.SaveChanges();
      return RedirectToAction("Index", "Home");
    }

    [HttpPost]
    public ActionResult AddFlavor(int id, int flavorId)
    {
      Treat treat = _db.Treats.FirstOrDefault(treat => treat.TreatId == id);
      
      #nullable enable
      FlavorTreat? joinEntity = _db.FlavorTreats.FirstOrDefault(join => (join.TreatId == treat.TreatId && join.FlavorId == flavorId));
      #nullable disable

      if (joinEntity == null && flavorId != 0)
      {
        _db.FlavorTreats.Add(new FlavorTreat() { TreatId = treat.TreatId, FlavorId = flavorId});
        _db.SaveChanges();
      }
      return RedirectToAction("Details", new { id = treat.TreatId });
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
