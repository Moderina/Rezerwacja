namespace Rezerwacja.Models
{
    public class RoomCategory
    {
        public int RoomId { get; set; }
        public Room Room { get; set; }

        public int CategoryId { get; set; }
        public Category Category { get; set; }
    }
}
