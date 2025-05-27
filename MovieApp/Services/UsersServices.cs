using MovieApp.Models;
using System.Collections.Generic;
using System.Linq;

namespace MovieApp.Services
{
    public static class UsersService
    {
        private static List<Users> users = new List<Users>();

        public static List<Users> GetAllUsers()
        {
            return users;
        }

        public static void RegisterUser(string firstName, string lastName)
        {
            if (!users.Any(u => u.FirstName == firstName && u.LastName == lastName))
            {
                users.Add(new Users
                {
                    UserID = users.Count + 1,
                    FirstName = firstName,
                    LastName = lastName,
                    Cart = new List<Movies>()
                });
            }
        }

        public static Users? GetUser(string firstName, string lastName)
        {
            return users.FirstOrDefault(u => u.FirstName == firstName && u.LastName == lastName);
        }

        public static bool AddMovieToCart(string firstName, string lastName, Movies movie)
        {
            var user = GetUser(firstName, lastName);
            if (user != null)
            {

                if (user.Cart.Any(m => m.MovieID == movie.MovieID))
                {
                    return false;
                }

                user.Cart.Add(new Movies
                {
                    MovieID = movie.MovieID,
                    Title = movie.Title,
                    Director = movie.Director,
                    Stars = movie.Stars,
                    ReleaseYear = movie.ReleaseYear,
                    ImageUrl = movie.ImageUrl,
                    IMDBRating = movie.IMDBRating,
                    ComingSoon = movie.ComingSoon
                });

                return true;
            }

            return false;
        }


        public static void RemoveMovieFromCart(string firstName, string lastName, int movieId)
        {
            var user = GetUser(firstName, lastName);
            if (user != null)
            {
                user.Cart.RemoveAll(m => m.MovieID == movieId);
            }
        }

        public static List<Movies>? GetCartMovies(string firstName, string lastName)
        {
            var user = GetUser(firstName, lastName);
            return user?.Cart;
        }
    }
}
