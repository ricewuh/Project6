namespace Project6.Models;

using System.ComponentModel.DataAnnotations;

public class Movie //the models hold the data entered in from the movie form
{
    [Key]
    public int MovieId { get; set; }

    [Required]
    public string Title { get; set; }

    [Required]
    public string Category { get; set; }

    [Required]
    public string Director { get; set; }

    [Required]
    public int Year { get; set; }

    [Required]
    public string Rating { get; set; }  // Dropdown (G, PG, PG-13, R)

    public bool Edited { get; set; }  // Yes/No (true/false)

    public string LentTo { get; set; }  // Optional

    [StringLength(25)]
    public string Notes { get; set; }  // Optional, max 25 chars
}
