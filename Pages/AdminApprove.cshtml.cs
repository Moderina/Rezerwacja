using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Rezerwacja.Interfaces;
using Rezerwacja.Models;
using System.Security.Claims;

namespace Rezerwacja.Pages
{
    public class AdminApproveModel : PageModel
    {
        public List<Reservation> Reservations { get; set; }

        public readonly IReservationService _reservationService;

        public AdminApproveModel(IReservationService reservationService)
        {
            _reservationService = reservationService;
        }
        public void OnGet()
        {
            Reservations = _reservationService.GetApproveReservations();
        }

        public void OnPostApprove(int id)
        {
            _reservationService.ApproveReservation(id);
            Reservations = _reservationService.GetApproveReservations();
        }

        public void OnPostCancel(int id)
        {
            _reservationService.RemoveReservation(id);
            Reservations = _reservationService.GetApproveReservations();
        }
    }
}
