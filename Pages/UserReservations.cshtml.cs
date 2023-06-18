using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Rezerwacja.Interfaces;
using Rezerwacja.Models;
using System.Security.Claims;

namespace Rezerwacja.Pages
{
    public class UserReservationsModel : PageModel
    {
        public List<Reservation> Reservations { get; set; }

        public readonly IReservationService _reservationService;

        public UserReservationsModel(IReservationService reservationService)
        {
            _reservationService = reservationService;
        }
        public void OnGet()
        {
            Reservations = _reservationService.GetUserReservations(User.FindFirstValue(ClaimTypes.NameIdentifier));
        }

        public void OnPost(int id)
        {
            _reservationService.RemoveReservation(id);
            Reservations = _reservationService.GetUserReservations(User.FindFirstValue(ClaimTypes.NameIdentifier));
        }
    }
}
