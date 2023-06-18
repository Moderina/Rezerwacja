using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Rezerwacja.Data;
using Rezerwacja.Models;

namespace Rezerwacja.Pages
{
    public class ManageBuildingsModel : PageModel
    {
        [BindProperty]
        public Building Building { get; set; }
        public List<Building> Buildings { get; set; }

        public readonly BookingContext _bookingContext;

        public ManageBuildingsModel(BookingContext bookingContext)
        {
            _bookingContext = bookingContext;
        }
        public void OnGet()
        {
            Buildings = _bookingContext.Buildings.ToList();
        }

        public void OnPostAddBuilding() 
        {
            _bookingContext.Buildings.Add(Building);
            _bookingContext.SaveChanges();
            Buildings = _bookingContext.Buildings.ToList();
        }

        public IActionResult OnPostGoToRooms(int buildID)
        {
            TempData["Building"] = buildID;
            return Redirect("/ManageRooms");
        }
    }
}
