using System.ComponentModel.DataAnnotations;

namespace Rezerwacja.Models
{
    public class Equipment
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
