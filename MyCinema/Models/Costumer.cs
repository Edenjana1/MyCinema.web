using System.ComponentModel.DataAnnotations;

namespace MyCinema.Models
{
    public enum Gender
    {
        Male, Female
    }
    public class Costumer
    {
        public int CustomerID { get; set; }
        [Key]
        public string LastName { get; set; }
        public string FirstMidName { get; set; }
        public Gender? Gender { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public DateTime BirthDate { get; set; }

        public ICollection<Purchase> Purchases { get; set; }
    }
}
