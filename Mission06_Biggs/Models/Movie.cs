using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mission06_Biggs.Models
{
    public class YearRangeAttribute : ValidationAttribute
    {
        public int MinYear { get; set; }
        public override bool IsValid(object value)
        {
            var year = (int)value;
            var isValid = year >= MinYear && year <= DateTime.Now.Year;
            ErrorMessage = $"Year must be between {MinYear} and {DateTime.Now.Year}";
            return isValid;
        }
    }
    public class Movie
    {

        [Key]
        [Required]
        public int MovieId { get; set; }

        [ForeignKey("CategoryId")]
        [Range(1, 8, ErrorMessage = "Please select a category")]
        public int CategoryId { get; set; }
        public Category? Category { get; set; }

        [Required(ErrorMessage = "Please enter a title")]
        public string Title { get; set; }
        [YearRange(MinYear = 1888)]
        public int Year { get; set; }
        public string? Director { get; set; }
        public string? Rating { get; set; }
        [Range(0, 1, ErrorMessage = "Please specify if the movie was edited")]
        public int Edited { get; set; }
        public string? LentTo { get; set; } = string.Empty;
        [Range(0, 1, ErrorMessage = "Please specify if the movie was copied to Plex")]
        public int CopiedToPlex { get; set; }
        public string? Notes { get; set; } = string.Empty;
    }
}
