using Microsoft.EntityFrameworkCore;

namespace Project6.Models; 
public class MovieContext : DbContext //Liasion from the app to the database
{
    public MovieContext(DbContextOptions<MovieContext> options) : base(options) //constructor
    {
    }
    public DbSet<Movie> Movies { get; set; } //This is the name of the table in our databse
    
}
