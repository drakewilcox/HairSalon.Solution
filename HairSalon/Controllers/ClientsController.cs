using Microsoft.AspNetCore.Mvc;
using HairSalon.Models;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace HairSalon.Controllers
{
  public class ClientsController : Controller
  {
    private readonly HairSalonContext _db;

    public ClientsController(HairSalonContext db)
    {
      _db = db;
    }

    public ActionResult Index()
    {
      List<Client> model = _db.Restaurants.Include(Clients => Clients.Stylist).ToList();
      return View(model);
    }
    public ActionResult Create()
    {
      ViewBag.CuisineId = new SelectList(_db.Stylists, "StylistId", "Name");
      return View();
    }
    [HttpPost]
    public ActionResult Create(Client client)
    {
      _db.Clients.Add(clients);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }
  }
}