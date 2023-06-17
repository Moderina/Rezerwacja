using Rezerwacja.Interfaces;
using Rezerwacja.Repositories;

namespace Rezerwacja.Services
{
    public class RoomService : IRoomService
    {
        public readonly IBuildingRepo _repo;

        public RoomService(IBuildingRepo repo)
        {
            _repo = repo;
        }

        public string GetCatNames(int roomId)
        {
            var list = _repo.GetCatNames(roomId);
            return string.Join(", ", list);
        }

        public string GetEqNames(int roomId)
        {
            var list = _repo.GetEqNames(roomId);
            return string.Join(", ", list);
        }
    }
}
