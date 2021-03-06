using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using HairSalon.Models;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;


namespace HairSalon.Controllers
{
  public class HomeController : Controller
  {
    private readonly HairSalonContext _db;

    public HomeController(HairSalonContext db)
    {
      _db = db;
    }

    [HttpGet("/")]
    public ActionResult Index()
    {
      return View();
    }
  }
}