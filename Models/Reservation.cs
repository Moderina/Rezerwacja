using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace Rezerwacja.Models
{
    public class Reservation
    {
        [Key]
        public int Id { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public string UserId { get; set; }  
        public int RoomId { get; set; }
        public bool Approved { get; set; } = false;

    }
}
