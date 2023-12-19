using TravelAgencyBack.Domain.Base;

namespace TravelAgencyBack.Domain
{
    public class Hotel : Entity
    {
        public string Name { get; set; }
        public int City { get; set; }
        public List<Room> Rooms { get; set; }

        public Hotel()
        {
            Name = string.Empty;
            Rooms = new List<Room>();
        }
    }
}