using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MovieApp.Core.Entities;
using MovieApp.DAL.Contexts;
using System.Formats.Asn1;

namespace MovieApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GenreController:Controller
    {
        private readonly AppDbContext _context;

        public GenreController(AppDbContext context)
        {
            _context = context;

        }

        [HttpGet]

        public async Task<IActionResult> GetMovies()
        { 
           var movies = await _context.Movies.ToListAsync();
           return Ok(movies);
        }

    }
}
