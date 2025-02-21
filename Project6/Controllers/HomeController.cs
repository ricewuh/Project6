using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
        ViewBag.Categories = _context.Categories.ToList();  // ✅ Passing categories for dropdown
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
        ViewBag.Categories = _context.Categories.ToList();  // ✅ Repopulate dropdown on validation fail
        return View(movie);
    }

    public IActionResult WaitList() //This is ensuring safe defaults in the controller
    {
        var movies = _context.Movies
            .Include(m => m.Category)
            .OrderBy(m => m.Title) // ✅ Sorts by Title ascending (numeric first, then alphabetical)
            .Select(m => new Movie
            {
                MovieId = m.MovieId,
                Title = m.Title ?? "Untitled",
                Category = m.Category ?? new Category { CategoryName = "Unknown" },
                Director = m.Director ?? "Unknown",
                Year = m.Year,
                Rating = m.Rating ?? "Not Rated",
                Edited = m.Edited,
                LentTo = m.LentTo ?? "None",
                Notes = m.Notes ?? "",
                CopiedToPlex = m.CopiedToPlex
            })
            .ToList();

        return View(movies);
    }

    // ✅ GET: Edit Movie
    [HttpGet]
    public IActionResult Edit(int id)
    {
        var movie = _context.Movies.FirstOrDefault(m => m.MovieId == id);
        if (movie == null)
        {
            return NotFound();
        }
        ViewBag.Categories = _context.Categories.ToList(); // Pass categories using ViewBag
        return View(movie);
    }
    //Post Edit Movie
    [HttpPost]
    public IActionResult Edit(Movie updatedMovie)
    {
        _context.Movies.Update(updatedMovie);
        _context.SaveChanges();
        return RedirectToAction("WaitList"); //returns back to waitlist
    }
    
    // ✅ GET: Show confirmation page
    [HttpGet]
    public IActionResult Delete(int id)
    {
        var movie = _context.Movies.FirstOrDefault(m => m.MovieId == id);
        if (movie == null)
        {
            return NotFound();
        }
        return View(movie);
    }
    
    // ✅ POST: Handle the deletion
    [HttpPost, ActionName("Delete")]
    public IActionResult DeleteConfirmed(int id)
    {
        var movie = _context.Movies.FirstOrDefault(m => m.MovieId == id);
        if (movie == null)
        {
            return NotFound();
        }

        _context.Movies.Remove(movie);
        _context.SaveChanges();
        return RedirectToAction("WaitList");
    }

}