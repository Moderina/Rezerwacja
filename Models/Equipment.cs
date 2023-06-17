using System.ComponentModel.DataAnnotations;

namespace Rezerwacja.Models
{
    public class Equipment
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<RoomEquipment> RoomEquipment { get; set; }
    }
}
