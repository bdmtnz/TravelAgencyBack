using TravelAgencyBack.Domain.Base;

namespace TravelAgencyBack.Domain
{
    public class Hotel : Entity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public double MinPrice => GetMinPrice();
        public List<Room> Rooms { get; set; }

        public Hotel()
        {
            Rooms = new List<Room>();
        }

        public Hotel(string name) : base()
        {
            Name = name;
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
    }
}