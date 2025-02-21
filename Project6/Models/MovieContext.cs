using Microsoft.EntityFrameworkCore;

namespace Project6.Models; 
public class MovieContext : DbContext //Liasion from the app to the database
{
    public MovieContext(DbContextOptions<MovieContext> options) : base(options) //constructor
    {
    }
    public DbSet<Movie> Movies { get; set; } //This is the name of the table in our database
    public DbSet<Category> Categories { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Seed Categories to match the database
        modelBuilder.Entity<Category>().HasData(
            new Category { CategoryID = 1, CategoryName = "Miscellaneous" },
            new Category { CategoryID = 2, CategoryName = "Drama" },
            new Category { CategoryID = 3, CategoryName = "Television" },
            new Category { CategoryID = 4, CategoryName = "Horror/Suspense" },
            new Category { CategoryID = 5, CategoryName = "Comedy" },
            new Category { CategoryID = 6, CategoryName = "Family" },
            new Category { CategoryID = 7, CategoryName = "Action/Adventure" },
            new Category { CategoryID = 8, CategoryName = "VHS" }
        );
    }
}

