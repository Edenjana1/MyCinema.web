using System.ComponentModel.DataAnnotations;

namespace MyCinema.Models
{
    public class Serie
    {
        public int SerieID { get; set; }
        [Key]
        public string SerieName { get; set; }
        public int SeasonNum { get; set; }
        public Genre? SerieGenre { get; set; }
        public DateTime ReleaseDate { get; set; }
        public string SerieDescription { get; set; }
        public string AgeRate { get; set; }
        public int SeriePrice { get; set; }

        public ICollection<Purchase> Purchases { get; set; }
    }
}
