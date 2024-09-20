using Microsoft.EntityFrameworkCore;
using MovieApp.Core.Entities;

namespace MovieApp.DAL.Contexts;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options){}


    public DbSet<Movie> Movies { get; set; }

    public DbSet<Movie> Genre { get; set; }

    public DbSet<Movie> Theater { get; set; }

    public DbSet<Movie> ShowTime { get; set; }

    public DbSet<Movie> User { get; set; }
}
