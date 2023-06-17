using Rezerwacja.Models;

namespace Rezerwacja.Interfaces
{
    public interface IBuildingRepo
    {
        public Building GetBuilding(int id);
        public List<Room> GetRooms(int buildID);
        public List<string> GetCatNames(int roomId);
        public List<string> GetEqNames(int roomId);

    }
}
