using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MovieStoreApp.Data;
using MovieStoreApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieStoreApp.Controllers
{
    public class MovieController : Controller
    {
        private readonly ApplicationDbContext _context;
        public MovieController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Registration()
        {
            return View();
        }

        public async Task<IActionResult> MovieList()
        {
            var movieList = await _context.Movie.ToListAsync();
            return View(movieList);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Title,Genre,Runtime")] MoviesModel moviesModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(moviesModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(MovieList));
            }
            return View(moviesModel);
        }
    }
}
