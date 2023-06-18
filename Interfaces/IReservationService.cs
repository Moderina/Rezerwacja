using Rezerwacja.Models;

namespace Rezerwacja.Interfaces
{
    public interface IReservationService
    {
        public void AddReservation(Reservation reservation);
        public List<Reservation> GetUserReservations(string userid);
        public List<Reservation> GetApproveReservations();
        public void ApproveReservation(int id);
        public void RemoveReservation(int id);

    }
}
