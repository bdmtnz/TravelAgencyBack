using TravelAgencyBack.Domain.Base;

namespace TravelAgencyBack.Domain
{
    public class Hotel : Entity
    {
        public string Name { get; private set; }
        public string Description { get; private set; }
        public string ImageUrl { get; private set; }
        public double MinPrice => GetMinPrice();
        public List<Room> Rooms { get; private set; }

        public Hotel()
        {
            Rooms = new List<Room>();
        }

        public Hotel(string name, string description, string imageUrl) : base()
        {
            Name = name;
            Description = description;
            ImageUrl = imageUrl;
            Rooms = new List<Room>();
        }

        public double GetMinPrice()
        {
            var minPrice = Rooms.MinBy(room => room.Price);
            return minPrice is null ? -1 : minPrice.Price;
        }

        public void AddRoom(Room room)
        {
            Rooms.Add(room);
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