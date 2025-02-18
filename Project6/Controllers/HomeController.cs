using Microsoft.AspNetCore.Mvc;
using Project6.Models;

namespace Project6.Controllers;

public class HomeController : Controller
{
    private readonly MovieContext _context;

    public HomeController(MovieContext context)
    {
        _context = context;
    }

    public IActionResult Index()
    {
        return View();
    }

    public IActionResult GetToKnow()
    {
        return View();
    }

    [HttpGet]
    public IActionResult Movie()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Movie(Movie movie)
    {
        if (ModelState.IsValid)
        {
            _context.Movies.Add(movie);
            _context.SaveChanges();
            return View("Confirmation", movie);
        }
        return View(movie);
    }
}