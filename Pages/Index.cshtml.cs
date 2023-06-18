using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Rezerwacja.Interfaces;
using Rezerwacja.Models;
using Rezerwacja.ViewModels;
using System.Security.Claims;

namespace Rezerwacja.Pages
{
    public class IndexModel : PageModel
    {
        [BindProperty]
        public SearchVM SearchVM { get; set; }

        [BindProperty]
        public List<Room> resultRooms { get; set; }

        [BindProperty]
        public List<Category> Categories { get; set; }

        [BindProperty]
        public List<Equipment> Equipment { get; set; }

        private readonly ILogger<IndexModel> _logger;
        private readonly IRoomService _roomService;
        private readonly IReservationService _resService;

        public IndexModel(ILogger<IndexModel> logger, IRoomService roomService, IReservationService resService)
        {
            _logger = logger;
            _roomService = roomService;
            _resService = resService;
        }

        public void OnGet()
        {
            Equipment = _roomService.GetEquipment();
            Categories = _roomService.GetCategories();
            resultRooms = _roomService.GetSearchRooms(SearchVM);
        }

        public void OnPostSearch(DateTime date)
        {
            resultRooms = _roomService.GetSearchRooms(SearchVM);
            Equipment = _roomService.GetEquipment();
            Categories = _roomService.GetCategories();
        }

        public void OnPostReserve(int roomId)
        {
            if (SearchVM.TimeStart >= DateTime.Now && SearchVM.TimeStart <= DateTime.Now.AddYears(2))
            {
                Reservation reservation = new Reservation
                {
                    RoomId = roomId,
                    StartTime = SearchVM.TimeStart,
                    EndTime = SearchVM.TimeStart,
                    UserId = User.FindFirstValue(ClaimTypes.NameIdentifier),
                };
                _resService.AddReservation(reservation);
            }
            resultRooms = _roomService.GetSearchRooms(SearchVM);
            Equipment = _roomService.GetEquipment();
            Categories = _roomService.GetCategories();
        }
    }
}