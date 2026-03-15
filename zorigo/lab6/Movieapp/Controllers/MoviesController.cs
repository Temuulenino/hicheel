using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MovieApp.Data;
using MovieApp.Models;

namespace MovieApp.Controllers
{
    public class MoviesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public MoviesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // Бүх кинонуудын жагсаалт
        public async Task<IActionResult> Index()
        {
            var movies = await _context.Movies
                .Include(m => m.Genre)
                .ToListAsync();
            return View(movies);
        }

        // Ангилалаар шүүх
        public async Task<IActionResult> FilterByGenre(string genre)
        {
            ViewBag.SelectedGenre = genre;
            var movies = await _context.Movies
                .Include(m => m.Genre)
                .Where(m => m.Genre.Name == genre)
                .ToListAsync();
            return View(movies);
        }

        // Статистик
        public async Task<IActionResult> Statistics()
        {
            var movies = await _context.Movies
                .Include(m => m.Genre)
                .ToListAsync();

            ViewBag.AverageRating = Math.Round(movies.Average(m => m.Rating), 2);
            ViewBag.TopRated = movies.OrderByDescending(m => m.Rating).First();
            ViewBag.LowestRated = movies.OrderBy(m => m.Rating).First();
            ViewBag.SortedMovies = movies.OrderByDescending(m => m.Rating).ToList();

            return View();
        }
    }
}   