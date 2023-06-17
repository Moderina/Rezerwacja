using Rezerwacja.Data;
using Rezerwacja.Interfaces;
using Rezerwacja.Models;

namespace Rezerwacja.Repositories
{
    public class BuildingRepo : IBuildingRepo
    {
        public readonly BookingContext _context;

        public BuildingRepo(BookingContext context)
        {
            _context = context;
        }

        public Building GetBuilding(int id)
        {
            return _context.Buildings.FirstOrDefault(d => d.Id == id);
        }

        public List<Room> GetRooms(int buildID)
        {
            return _context.Rooms.Where(r => r.buildingId == buildID).ToList();
        }

        public List<string> GetCatNames(int roomId)
        {
            List<string> result = new List<string>();
            //var catId = _context.RoomCategories.Where(d => d.RoomId == roomId).ToList().Select(obj => obj.CategoryId).ToList(); ;
            //foreach (var cat in catId)
            //{
            //    System.Diagnostics.Debug.WriteLine("ZZZZZZZZ" + _context.Categories.FirstOrDefault(d => d.Id == cat).Name);
            //    result.Add(_context.Categories.FirstOrDefault(d => d.Id == cat).Name);
            //}
            return result;
        }

        public List<string> GetEqNames(int roomId)
        {
            List<string> result = new List<string>();
            //var eqId = _context.RoomEquipment.Where(d => d.RoomId == roomId).ToList().Select(obj => obj.EquipmentId).ToList(); ;
            //foreach (var cat in eqId)
            //{
            //    System.Diagnostics.Debug.WriteLine("ZZZZZZZZ" + _context.Equipment.FirstOrDefault(d => d.Id == cat).Name);
            //    result.Add(_context.Equipment.FirstOrDefault(d => d.Id == cat).Name);
            //}
            return result;
        }

    }
}
