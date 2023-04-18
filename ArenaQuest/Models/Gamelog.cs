using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace ArenaQuest.Models

{
    public enum League
    {
        NBA,
        NHL,
        NFL,
        MLB
    }
    public class Gamelog
    {

        public int Id { get; set; } // Unique identifier for the game log entry

        [Display(Name = "Home Team")]
        [StringLength(60, MinimumLength = 3)]
        [Required]
        public string? Team1 { get; set; } // First team

        [StringLength(60, MinimumLength = 3)]
        [Required]
        [Display(Name = "Away Team")]
        public string? Team2 { get; set; } // Second team

        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Required]
        public DateTime Date { get; set; } // Date of the game

        [Required]
        public League League { get; set; } // League of the game

        [StringLength(60, MinimumLength = 3)]
        [Required]
        public string? Arena { get; set; } // Arena

        public string? Comments { get; set; } // Comments about the game or arena

        [Range(1, 5)]
        public int Rating { get; set; } // Rating out of 5 stars


    }
}
