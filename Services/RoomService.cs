using Rezerwacja.Interfaces;
using Rezerwacja.Models;
using Rezerwacja.Repositories;
using Rezerwacja.ViewModels;

namespace Rezerwacja.Services
{
    public class RoomService : IRoomService
    {
        public readonly IBuildingRepo _repo;

        public RoomService(IBuildingRepo repo)
        {
            _repo = repo;
        }

        public List<Category> GetCategories()
        {
            return _repo.GetCategories();
        }

        public List<Equipment> GetEquipment()
        {
            return _repo.GetEquipment();
        }

        public List<Room> GetRooms(int buildId)
        {
            return _repo.GetRooms(buildId);
        }
        public List<Room> GetSearchRooms(SearchVM searchVM)
        {
            return _repo.GetSearchRooms(searchVM);
        }


        public List<RoomVM> GetRoomVMs(int buildId)
        {
            var roomlist = GetRooms(buildId);
            List<RoomVM> rooms = new List<RoomVM>();
            foreach (var room in roomlist)
            {

                rooms.Add(new RoomVM
                {
                    Id = room.Id,
                    MaxPeople = room.MaxPeople,
                    Category = room.Category,
                    Equipment = room.Equipment
                });
            }
            return rooms;
        }

        public void checkEq(string eq)
        {
            List<string> eqs = eq.Split(',').ToList();
            foreach (var e in eqs)
            {
                if (!_repo.EqExists(e)) _repo.AddEq(e);
            }
        }

        public void AddCategory(string name)
        {
            if (!_repo.CatExists(name)) 
            {
                _repo.AddCategory(name);
            }
        }
    }
}
