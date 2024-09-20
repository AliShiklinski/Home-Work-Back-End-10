using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MovieApp.Core.Entities;
using MovieApp.DAL.Contexts;

namespace MovieApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TheaterController:Controller
    {

        private readonly AppDbContext _context;

        public TheaterController(AppDbContext context)
        {
            _context = context;

        }

        [HttpGet]

        public async Task<IActionResult> GetMovies()
        {
            var movies = await _context.Movies.ToListAsync();
            return Ok(movies);
        }

        private IActionResult Ok(List<Movie> movies)
        {
            throw new NotImplementedException();
        }

        [HttpGet("{Id}")]

        public async Task<IActionResult> GetMovie(int Id)
        {
            var movie = await _context.Movies.FindAsync(Id);
            if (movie == null) return NotFound();

            return Ok();

        }


    }
}
