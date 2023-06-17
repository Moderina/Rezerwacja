using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
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
        public string category { get; set; }

        public List<Category> Categories { get; set; }

        [BindProperty]
        public string Eq { get; set; }

        [BindProperty(SupportsGet = true)]
        public Building Building { get; set; }

        public int buildid { get; set; }

        [BindProperty]
        public List<RoomVM> rooms { get; set; } = new List<RoomVM>();

        public readonly BookingContext _context;

        public readonly IBuildingRepo _buildingRepo;
        public readonly IRoomService _roomService;


        public ManageRoomsModel(BookingContext context, IBuildingRepo buildingRepo, IRoomService room) 
        {
            _context = context;
            _buildingRepo = buildingRepo;
            _roomService = room;
        }
        public IActionResult OnGet()
        {
            if (TempData.TryGetValue("Building", out var buildingIdObj) && int.TryParse(buildingIdObj?.ToString(), out var buildingID))
            {
                //this.Building = _buildingRepo.GetBuilding(buildingID);
                buildid = buildingID;
            }
            var roomlist = _buildingRepo.GetRooms(buildid);
            foreach (var room in roomlist)
            {
                //System.Diagnostics.Debug.WriteLine("SSSSSSS" + room.RoomCategories);

                rooms.Add(new RoomVM
                {
                    Id = room.Id,
                    MaxPeople = room.MaxPeople,
                    Categories = room.Category,
                    Equipment = room.Equipment
                });
            }
            Categories = _context.Categories.ToList();

            return Page();
        }

        public void OnPostAddRoom(int buildID)
        {
            //var categories = _context.Categories.ToList();

            //Category checkcategory = categories.FirstOrDefault(d => d.Name == category);

            //if (checkcategory == null)
            //{
            //    checkcategory = new Category();
            //    checkcategory.Name = category;
            //    _context.Categories.Add(checkcategory);
            //    _context.SaveChanges();
            //}
            System.Diagnostics.Debug.WriteLine("KKKKKKKKK" + buildID);


            Room Room = new Room()
            {
                MaxPeople = room.MaxPeople,
                Category = category,
                Equipment = Eq,
                buildingId = buildID,
            };
            _context.Rooms.Add(Room);
            _context.SaveChanges();





            //if (checkcategory == null)
            //{
            //    checkcategory = new Category();
            //    checkcategory.Name = category;
            //    _context.Categories.Add(checkcategory);
            //    _context.SaveChanges();

            //}

            //RoomCategory roomcategory = new RoomCategory
            //{
            //    Room = room,
            //    CategoryId = checkcategory.Id,
            //};
            //room.RoomCategories = new List<RoomCategory>
            //{
            //    roomcategory
            //};
            //_context.Rooms.Add(room);
            //_context.SaveChanges();
            //roomcategory.RoomId = room.Id;
            //_context.RoomCategories.Add(roomcategory);
            //_context.SaveChanges();

            //room.RoomCategories = new List<RoomCategory>
            //{
            //    roomcategory
            //};
            /*            if (TempData.TryGetValue("Building", out var buildingIdObj) && int.TryParse(buildingIdObj?.ToString(), out var buildingID))
                        {
                            building = _buildingRepo.GetBuilding(buildingID);
                            System.Diagnostics.Debug.WriteLine("JJJJJJJJJJJ" + building);
                        }*/



        }
    }
}
