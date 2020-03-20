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
      List<Client> model = _db.Clients.Include(Clients => Clients.Stylist).ToList();
      return View(model);
    }
    public ActionResult Create(int id)
    {
      var thisStylist = _db.Stylists.FirstOrDefault(stylists => stylists.StylistId == id);
      ViewBag.Stylist = thisStylist;
      return View();
    }
    [HttpPost]
    public ActionResult Create(Client client)
    {
      _db.Clients.Add(client);
      _db.SaveChanges();
      return RedirectToAction("Details", "Stylists", new { id = client.StylistId});
    }
    public ActionResult Details(int id)
    {
      Client thisClient = _db.Clients.FirstOrDefault(clients => clients.ClientId == id);
      Stylist thisStylist = _db.Stylists.FirstOrDefault(stylist => stylist.StylistId == thisClient.StylistId);
      
      return View(thisClient);
    }
  }
}