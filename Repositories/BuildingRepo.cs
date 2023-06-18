using Rezerwacja.Data;
using Rezerwacja.Interfaces;
using Rezerwacja.Models;
using Rezerwacja.ViewModels;

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

        public List<Room> GetSearchRooms(SearchVM searchVM)
        {
            var result = _context.Rooms.ToList();

            if (searchVM == null)
            {
                return result;
            }
            if (searchVM.MaxPeople != null)
            {
                result = result.Where(d => d.MaxPeople >= searchVM.MaxPeople).ToList();
            }
            if (searchVM.Category != null)
            {
                foreach (var cat in searchVM.Category)
                {
                    result = result.Where(d => d.Category.Contains(cat)).ToList();
                }
            }
            if (searchVM.Equipment != null)
            {
                foreach (var eq in searchVM.Equipment)
                {
                    result = result.Where(d => d.Equipment.Contains(eq)).ToList();
                }
            }
            var reservations = _context.Reservations.Where(d => d.StartTime.Date == searchVM.TimeStart).ToList();
            result = result.Where(d => !reservations.Select(r => r.RoomId).Contains(d.Id)).ToList();
            return result;
        }

        public List<Category> GetCategories()
        {
            return _context.Categories.ToList();
        }

        public List<Equipment> GetEquipment()
        {
            return _context.Equipment.ToList();
        }

        public bool EqExists(string name)
        {
            var result = _context.Equipment.Where(d => d.Name == name);
            return result.Any();
        }

        public void AddEq(string name)
        {
            Equipment eq = new Equipment { Name = name };
            _context.Equipment.Add(eq);
            _context.SaveChanges();
        }

        public bool CatExists(string name)
        {
            var result = _context.Categories.Where(d => d.Name == name);
            return result.Any();
        }

        public void AddCategory(string name)
        {
            Category cat = new Category { Name = name };
            _context.Categories.Add(cat);
            _context.SaveChanges();
        }

        public void AddReservation(Reservation reservation)
        {
            _context.Reservations.Add(reservation);
            _context.SaveChanges();
        }

        public List<Reservation> GetUserReservations(string userid)
        {
            return _context.Reservations.Where(d => d.UserId == userid).ToList();
        }

        public List<Reservation> GetApproveReservations()
        {
            return _context.Reservations.Where(d => !d.Approved).ToList();
        }

        public void ApproveReservation(int id)
        {
            Reservation re = _context.Reservations.FirstOrDefault(d => d.Id == id);
            re.Approved = true;
            _context.SaveChanges();
        }

        public void RemoveReservation(int id)
        {
            Reservation re = _context.Reservations.FirstOrDefault(d => d.Id == id);
            _context.Reservations.Remove(re);
            _context.SaveChanges();
        }
    }
}
