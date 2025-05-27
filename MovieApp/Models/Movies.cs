using System.ComponentModel.DataAnnotations;

namespace MovieApp.Models
{
    public class Movies
    {
        [Key]
        public int MovieID { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string Director { get; set; }

        [Required]
        public string[] Stars { get; set; }

        public int ReleaseYear { get; set; }

        public string ImageUrl { get; set; }

        [Range(0, 10)]
        public double IMDBRating { get; set; }

        public bool ComingSoon { get; set; }
    }
}
