using Rezerwacja.Models;
using Rezerwacja.ViewModels;

namespace Rezerwacja.Interfaces
{
    public interface IRoomService
    {
        public List<Category> GetCategories();
        public List<Equipment> GetEquipment();
        public void checkEq(string eq);
        public void AddCategory(string name);

        public List<Room> GetRooms(int buildId);
        public List<Room> GetSearchRooms(SearchVM searchVM);
        public List<RoomVM> GetRoomVMs(int buildId);

    }
}
