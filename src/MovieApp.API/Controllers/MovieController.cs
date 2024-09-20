using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MovieApp.Core.Entities;
using MovieApp.DAL.Contexts;

namespace MovieApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieController
    {
        public class MoviesController : Controller
        {
            private readonly AppDbContext _context;

            public MoviesController(AppDbContext context)
            {
                _context = context;
            }


            [HttpGet]
            public async Task<IActionResult> GetMovies()
            {
                var movies = await _context.Movies.ToListAsync();
                return Ok(movies);
            }

            [HttpGet("{Id}")]
            public async Task<IActionResult> GetMovie(int Id)
            {
                var movie = await _context.Movies.FindAsync(Id);
                if (movie == null) return NotFound();

                return Ok(movie);
            }

            [HttpPost]
            public async Task<IActionResult> CreateMovie([FromBody] Movie movie)
            {
                if (!ModelState.IsValid) return BadRequest(ModelState);

                Movie movie1 = new Movie()
                {

                    Id = movie.Id,
                    Title = movie.Title,
                    Description = movie.Description,
                    Duration = movie.Duration,
                    ShowTimes = movie.ShowTimes,
                    ReleaseDate = movie.ReleaseDate,
                    Genres = movie.Genres,
                    Rating = movie.Rating

                };

                movie1 = movie as Movie;
                _context.Movies.Add(movie);
                await _context.SaveChangesAsync();

                return CreatedAtAction(nameof(GetMovie), new { Id = movie.Id }, movie);
            }

            [HttpPut("{Id}")]
            public async Task<IActionResult> UpdateMovie(int Id, [FromBody] Movie movie)
            {
                if (Id != movie.Id)
                    return BadRequest();

                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                _context.Entry(movie).State = EntityState.Modified;

                try
                {
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MovieExists(Id))
                        return NotFound();

                    throw;
                }

                return NoContent();
            }

            [HttpDelete("{Id}")]
            public async Task<IActionResult> DeleteMovie(int Id)
            {
                var movie = await _context.Movies.FindAsync(Id);
                if (movie == null) return NotFound();

                _context.Movies.Remove(movie);
                await _context.SaveChangesAsync();

                return NoContent();
            }
            private bool MovieExists(int Id)
            {
                return _context.Movies.Any(e => e.Id == Id);

            }
        }
    }


}

