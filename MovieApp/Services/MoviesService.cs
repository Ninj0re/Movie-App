using MovieApp.Models;
using System.Collections.Generic;
using System.Linq;

namespace MovieApp.Services
{
    public static class MoviesService
    {
        private static List<Movies> _movies = new List<Movies>
        {
            new Movies { MovieID = 1, Title = "X-Men: The Last Stand", Director = "Brett Ratner", Stars = new string[] { "Patrick Stewart", "Hugh Jackman", "Halle Berry" }, ReleaseYear = 2006, ImageUrl = "/images/xmen.jpg", IMDBRating = 6.7, ComingSoon = false },
            new Movies { MovieID = 2, Title = "Spider Man 2", Director = "Sam Raimi", Stars = new string[] { "Tobey Maguire", "Kirsten Dunst", "Alfred Molina" }, ReleaseYear = 2004, ImageUrl = "/images/spiderman2.jpg", IMDBRating = 7.3, ComingSoon = false },
            new Movies { MovieID = 3, Title = "Gladiator", Director = "Ridley Scott", Stars = new string[] { "Russell Crowe", "Joaquin Phoenix", "Connie Nielsen" }, ReleaseYear = 2000, ImageUrl = "/images/gladiator.jpg", IMDBRating = 8.5, ComingSoon = false },
            new Movies { MovieID = 4, Title = "The Dark Knight", Director = "Christopher Nolan", Stars = new string[] { "Christian Bale", "Heath Ledger", "Aaron Eckhart" }, ReleaseYear = 2008, ImageUrl = "/images/darkknight.jpg", IMDBRating = 9.0, ComingSoon = false },
            new Movies { MovieID = 5, Title = "Inception", Director = "Christopher Nolan", Stars = new string[] { "Leonardo DiCaprio", "Joseph Gordon-Levitt", "Elliot Page" }, ReleaseYear = 2010, ImageUrl = "/images/inception.jpg", IMDBRating = 8.8, ComingSoon = false },
            new Movies { MovieID = 6, Title = "Titanic", Director = "James Cameron", Stars = new string[] { "Leonardo DiCaprio", "Kate Winslet", "Billy Zane" }, ReleaseYear = 1997, ImageUrl = "/images/titanic.jpg", IMDBRating = 7.8, ComingSoon = false },
            new Movies { MovieID = 7, Title = "The Matrix", Director = "Lana Wachowski, Lilly Wachowski", Stars = new string[] { "Keanu Reeves", "Laurence Fishburne", "Carrie-Anne Moss" }, ReleaseYear = 1999, ImageUrl = "/images/matrix.jpg", IMDBRating = 8.7, ComingSoon = false },
            new Movies { MovieID = 8, Title = "Avatar", Director = "James Cameron", Stars = new string[] { "Sam Worthington", "Zoe Saldana", "Sigourney Weaver" }, ReleaseYear = 2009, ImageUrl = "/images/avatar.jpg", IMDBRating = 7.8, ComingSoon = false },
            new Movies { MovieID = 9, Title = "The Avengers", Director = "Joss Whedon", Stars = new string[] { "Robert Downey Jr.", "Chris Evans", "Scarlett Johansson" }, ReleaseYear = 2012, ImageUrl = "/images/avengers.jpg", IMDBRating = 8.0, ComingSoon = false },
            new Movies { MovieID = 10, Title = "Interstellar", Director = "Christopher Nolan", Stars = new string[] { "Matthew McConaughey", "Anne Hathaway", "Jessica Chastain" }, ReleaseYear = 2014, ImageUrl = "/images/interstellar.jpg", IMDBRating = 8.6, ComingSoon = false },

            new Movies { MovieID = 11, Title = "Dune: Part Two", Director = "Denis Villeneuve", Stars = new string[] { "Timothée Chalamet", "Zendaya", "Rebecca Ferguson" }, ReleaseYear = 2024, ImageUrl = "/images/dune2.jpg", IMDBRating = 0.0, ComingSoon = true },
            new Movies { MovieID = 12, Title = "Deadpool & Wolverine", Director = "Shawn Levy", Stars = new string[] { "Ryan Reynolds", "Hugh Jackman", "Morena Baccarin" }, ReleaseYear = 2024, ImageUrl = "/images/deadpool3.jpg", IMDBRating = 0.0, ComingSoon = true },
            new Movies { MovieID = 13, Title = "The Batman: Part II", Director = "Matt Reeves", Stars = new string[] { "Robert Pattinson", "Zoë Kravitz", "Colin Farrell" }, ReleaseYear = 2025, ImageUrl = "/images/batman2.jpg", IMDBRating = 0.0, ComingSoon = true },
            new Movies { MovieID = 14, Title = "Star Wars: Episode III - Revenge of the Sith", Director = "George Lucas", Stars = new string[] { "Ewan McGregor", "Natalie Portman", "Hayden Christensen" }, ReleaseYear = 2005, ImageUrl = "/images/starwars3.jpg", IMDBRating = 7.6, ComingSoon = true },
            new Movies { MovieID = 15, Title = "Fantastic Four (MCU)", Director = "Matt Shakman", Stars = new string[] { "TBA" }, ReleaseYear = 2025, ImageUrl = "/images/fantasticfour.jpg", IMDBRating = 0.0, ComingSoon = true }

        };

        public static List<Movies> GetAllMovies()
        {
            return _movies;
        }

        public static Movies GetMovieById(int id)
        {
            return _movies.FirstOrDefault(m => m.MovieID == id);
        }
    }
}
