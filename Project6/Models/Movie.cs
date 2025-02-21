namespace Project6.Models;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class Movie
{
    [Key]
    public int MovieId { get; set; }

    [Required]
    public int CategoryID { get; set; } // Assuming CategoryID is always present

    [ForeignKey("CategoryID")]
    public Category? Category { get; set; } // Nullable navigation for safety

    [Required]
    public string? Title { get; set; } // Nullable in case of NULL in DB

    [Required]
    [Range(1888, 2100, ErrorMessage = "Year must be 1888 or later.")]
    public int Year { get; set; }

    public string? Director { get; set; } // Nullable

    public string? Rating { get; set; }   // Nullable

    public bool Edited { get; set; }

    public string? LentTo { get; set; }  // Optional

    public bool CopiedToPlex { get; set; }

    [StringLength(25)]
    public string? Notes { get; set; }  // Optional
}