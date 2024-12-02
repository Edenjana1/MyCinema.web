using System.ComponentModel.DataAnnotations;

namespace MyCinema.Models
{
    public class Purchase
    {
        public int PurchaseID { get; set; }
        [Key]
        public int MovieID { get; set; }
        public int SerieID { get; set; }
        public int CostumerID { get; set; }
        public DateTime PurchaseDate { get; set; }


        public Movie Movies { get; set; }
        public Serie Series { get; set; }
        public Costumer Costumers { get; set; }

    }
}
