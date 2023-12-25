using TravelAgencyBack.Domain.Base;
using TravelAgencyBack.Domain.ValueObjects;

namespace TravelAgencyBack.Domain
{
    public class Hotel : Entity
    {
        public string Name { get; private set; }
        public string Description { get; private set; }
        public string ImageUrl { get; private set; }
        public double MinPrice => GetMinPrice();
        public ICollection<Room> Rooms { get; private set; }

        public Hotel() { }

        public Hotel(string name, string description, string imageUrl) : base()
        {
            Name = name;
            Description = description;
            ImageUrl = imageUrl;
            Rooms = new List<Room>();
        }

        public double GetMinPrice()
        {
            if(Rooms is null) return -1;
            var minPrice = Rooms.MinBy(room => room.Price);
            return minPrice is null ? -1 : minPrice.Price;
        }

        public Room AddRoom(string location, RoomType type, double cost, double tax, double profit, int capacity, string city, string imageUrl)
        {
            if(Rooms is null) Rooms = new List<Room>();
            var room = new Room(
                    this,
                    location,
                    type,
                    cost,
                    tax,
                    profit,
                    capacity,
                    city,
                    imageUrl
                );
            Rooms.Add(room);
            return room;
        }

        public DomainResponse<Booking> AddBooking(Room room, Traveler traveler, List<Person> guests, Contact emergencyContact, DateTime start, DateTime end, string city) 
        {
            var quantityPeople = guests.Count + 1;
            if(quantityPeople > room.Capacity) {                
                return new DomainResponse<Booking>(true, Resources.ErrorResponsesES.EXCEDEED_ROOM_CAPACITY, default);
            }
            var response = room.AddBooking(traveler, guests, emergencyContact, start, end, city);
            if(response.HaveError)
            {
                return response;
            }
            var booking = response.Data;
            traveler.AddBooking(booking);
            return new DomainResponse<Booking>(false, Resources.OkResponsesES.BOOKING_SUCCESSFUL, booking);
        }

        public List<Room> GetAvalibleRooms(int quantitypeople, DateTime start, DateTime end, string city)
        {
            var rooms = Rooms.Where(room => room.CanBooking(quantitypeople, start, end, city));
            return rooms.ToList();
        }

        public void Update(string name, string description, string imageUrl)
        {
            Name = name;
            Description = description;
            ImageUrl = imageUrl;
        }
    }
}