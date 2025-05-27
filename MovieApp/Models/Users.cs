using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MovieApp.Models
{
    public class Users
    {
        [Key]
        public int UserID { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        public List<Movies> Cart { get; set; } = new List<Movies>();
    }
}
