using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelAgencyBack.Domain.Base;
using TravelAgencyBack.Domain.ValueObjects;

namespace TravelAgencyBack.Domain
{
    public class Agency : Entity
    {
        public string Name { get; set; }
        public Credential<Agency> Credential { get; set; }
        public List<Hotel> Hotels { get; set; }
        public List<Person> Clients { get; set; }

        public Agency()
        {
            
        }

        public Agency(string name, Credential<Agency> credential) : base()
        {
            Name = name;
            Credential = credential;
            Hotels = new List<Hotel>();
            Clients = new List<Person>();
        }

        public DomainResponse<Hotel> AddHotel(Hotel hotel)
        {
            if(hotel.Rooms.Count <= 0)
            {
                return new DomainResponse<Hotel>(true, Resources.ErrorResponsesES.HOTEL_NEED_A_ROOM, hotel);
            }
            Hotels.Add(hotel);
            return new DomainResponse<Hotel>(true, Resources.OkResponsesES.ADD_HOTEL_SUCCESSFUL, hotel);
        }

        public DomainResponse<Booking> AddBooking(Hotel hotel, Room room, Traveler traveler, List<Person> guests, Contact emergencyContact, DateTime start, DateTime end, string city)
        {
            var response = hotel.AddBooking(room, traveler, guests, emergencyContact, start, end, city);
            if(!response.HaveError)
            {
                Clients.Add(traveler);
            }
            return response;
        }
    }
}
