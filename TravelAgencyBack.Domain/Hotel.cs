using TravelAgencyBack.Domain.Base;

namespace TravelAgencyBack.Domain
{
    public class Hotel : Entity
    {
        public string Name { get; set; }
        public string City { get; set; }
        public List<Room> Rooms { get; set; }

        public Hotel(string name, string city) : base()
        {
            Name = name;
            City = city;
            Rooms = new List<Room>();
        }

        public void AddRoom(Room room)
        {
            Rooms.Add(room);
        }

        public DomainResponse<Booking> AddBooking(Room room, Traveler traveler, List<Person> guests, Contact emergencyContact, DateTime start, DateTime end) 
        {
            var quantityPeople = guests.Count + 1;
            if(quantityPeople > room.Capacity) {                
                return new DomainResponse<Booking>(true, Resources.ErrorResponsesES.EXCEDEED_ROOM_CAPACITY, default);
            }
            var booking = room.AddBooking(traveler, guests, emergencyContact, start, end);
            traveler.AddBooking(booking);
            return new DomainResponse<Booking>(false, Resources.OkResponsesES.BOOKING_SUCCESSFUL, booking);
        }

        public List<Room> GetAvalibleRooms(int quantitypeople, DateTime start, DateTime end)
        {
            var rooms = Rooms.Where(room => room.CanBooking(quantitypeople, start, end));
            return rooms.ToList();
        }
    }
}