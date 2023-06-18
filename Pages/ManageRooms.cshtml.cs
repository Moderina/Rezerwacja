using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Rezerwacja.Data;
using Rezerwacja.Interfaces;
using Rezerwacja.Models;
using Rezerwacja.Repositories;
using Rezerwacja.Services;
using Rezerwacja.ViewModels;

namespace Rezerwacja.Pages
{
    public class ManageRoomsModel : PageModel
    {
        [BindProperty]
        public RoomVM room { get; set; }

        [BindProperty]
        public List<string> category { get; set; }

        [BindProperty]
        public string newCategory { get; set; }

        [BindProperty]
        public int buildid { get; set; }

        [BindProperty]
        public List<RoomVM> rooms { get; set; } = new List<RoomVM>();

        [BindProperty]
        public List<Category> Categories { get; set; }

        public readonly BookingContext _context;

        public readonly IRoomService _roomService;


        public ManageRoomsModel(BookingContext context, IRoomService room) 
        {
            _context = context;
            _roomService = room;
        }
        public IActionResult OnGet()
        {
            if (TempData.TryGetValue("Building", out var buildingIdObj) && int.TryParse(buildingIdObj?.ToString(), out var buildingID))
            {
                buildid = buildingID;
            }
            System.Diagnostics.Debug.WriteLine("vvvvvvv" + buildid);

            rooms = _roomService.GetRoomVMs(buildid);
            Categories = _roomService.GetCategories();

            return Page();
        }

        public void OnPostAddRoom(int buildID)
        {
            _roomService.checkEq(room.Equipment);
            System.Diagnostics.Debug.WriteLine("vvvvvvv" + buildid);
            System.Diagnostics.Debug.WriteLine("vvvvvvv" + buildID);

            Room Room = new Room()
            {
                MaxPeople = room.MaxPeople,
                Category = string.Join(",", category),
                Equipment = room.Equipment,
                buildingId = buildID,
            };
            _context.Rooms.Add(Room);
            _context.SaveChanges();

            rooms = _roomService.GetRoomVMs(buildID);
            Categories = _roomService.GetCategories();
        }

        public void OnPostAddCategory(int buildID)
        {
            _roomService.AddCategory(newCategory);
            rooms = _roomService.GetRoomVMs(buildID);
            Categories = _roomService.GetCategories();
        }
    }
}
