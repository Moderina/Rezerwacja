namespace Rezerwacja.ViewModels
{
    public class SearchVM
    {
        public List<string> Category { get; set; }
        public List<string> Equipment { get; set; }
        public DateTime TimeStart { get; set; }
        public DateTime TimeEnd { get; set; }
        public int MaxPeople { get; set; }
    }
}
