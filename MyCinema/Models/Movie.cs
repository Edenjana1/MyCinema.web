using System.ComponentModel.DataAnnotations;

namespace MyCinema.Models
{
    public enum Genre
    {
        Drama, Horror, Thriller, Romantic, Comady, SciFi, Action, Crime , Fantasy
    }
    public class Movie
    {
        public string MovieID { get; set; }
        public string MovieName { get; set; }
        public Genre? MovieGenre { get; set; }
        public string MovieDescription { get; set; }
        public DateTime ReleaseDate { get; set; }
        public string AgeRate { get; set; }
        public int MoviePrice { get; set; }

        public ICollection<Purchase> Purchases { get; set; }
    }
}
