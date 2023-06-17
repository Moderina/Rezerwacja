using System.ComponentModel.DataAnnotations;

namespace Rezerwacja.Models
{
    public class Room
    {
        [Key]
        public int Id { get; set; }
        public int MaxPeople { get; set; }

        public int buildingId { get; set; }
        public virtual Building Building { get; set; }
        public string Category { get; set; }
        public string Equipment { get; set; }
    }
}
