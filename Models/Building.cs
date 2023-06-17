using System.ComponentModel.DataAnnotations;

namespace Rezerwacja.Models
{
    public class Building
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string ZipCode { get; set; }
        public ICollection<Room>? Rooms { get; set; }
    }
}
