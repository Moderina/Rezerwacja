using Rezerwacja.Interfaces;
using Rezerwacja.Models;

namespace Rezerwacja.Services
{
    public class ReservationService : IReservationService
    {
        public readonly IBuildingRepo _repo;

        public ReservationService(IBuildingRepo repo)
        {
            _repo = repo;
        }

        public void AddReservation(Reservation reservation)
        {

            _repo.AddReservation(reservation);
        }

        public List<Reservation> GetUserReservations(string userid) 
        {
            return _repo.GetUserReservations(userid);
        }
        public List<Reservation> GetApproveReservations()
        {
            return _repo.GetApproveReservations();
        }
        public void ApproveReservation(int id)
        {
            _repo.ApproveReservation(id);
        }


        public void RemoveReservation(int id)
        {
            _repo.RemoveReservation(id);
        }


    }
}
