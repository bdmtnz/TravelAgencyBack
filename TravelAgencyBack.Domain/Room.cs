﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelAgencyBack.Domain.Base;
using TravelAgencyBack.Domain.ValueObjects;

namespace TravelAgencyBack.Domain
{
    public enum RoomType
    {
        Sencilla,
        Matrimonial,
        Familiar
    }

    public class Room : Entity
    {
        public Hotel Hotel { get; private set; }
        public string Location { get; private set; }
        public RoomType Type { get; private set; }
        public double Cost { get; private set; }
        public double Tax { get; private set; }
        public double Profit { get; private set; }
        public int Capacity { get; private set; }
        public string City { get; private set; }
        public string ImageUrl { get; private set; }
        public double Price => GetPrice();
        public ICollection<Booking> Bookings { get; private set; }

        public Room()
        {
            
        }

        internal Room(Hotel hotel, string location, RoomType type, double cost, double tax, double profit, int capacity, string city, string imageUrl) : base()
        {
            //Hotel = hotel;
            Location = location;
            Type = type;
            Cost = cost;
            Tax = tax;
            Profit = profit;
            Capacity = capacity;
            City = city;
            ImageUrl = imageUrl;
            Bookings = new List<Booking>();
        }

        private double GetPrice()
        {
            var taxxes = Cost * (Tax / 100);
            var profit = Cost * (Profit / 100);
            return Cost + taxxes + profit;
        }

        public DomainResponse<Booking> AddBooking(Traveler traveler, ICollection<Person> guests, Contact emergencyContact, DateTime start, DateTime end, string city)
        {
            var quantityPeople = guests.Count + 1;
            var canBooking = CanBooking(quantityPeople, start, end, city);

            if (!canBooking)
            {
                return new DomainResponse<Booking>(true, Resources.ErrorResponsesES.CANT_BOOKING_A_ROOM, default);
            }

            var booking = new Booking(this, traveler, guests, emergencyContact, start, end);
            Bookings.Add(booking);
            return new DomainResponse<Booking>(false, Resources.OkResponsesES.BOOKING_SUCCESSFUL, booking);
        }

        public bool CanBooking(int quantityPeople, DateTime start, DateTime end, string city)
        {
            if (city.ToLower() != City.ToLower()) return false;
            if(quantityPeople > Capacity) return false;
            if(!Hotel.Enabled || !Enabled) return false;
            var bookings = Bookings.Where(booking => booking.Start <= end && booking.End >= start && booking.Enabled);
            return !bookings.Any();
        }

        public bool CanBookingOverAll(DateTime start, DateTime end)
        {
            if (!Hotel.Enabled || !Enabled) return false;
            var bookings = Bookings.Where(booking => booking.Start <= end && booking.End >= start && booking.Enabled);
            return !bookings.Any();
        }

        public void Update(string location, RoomType type, double cost, double tax, double profit, int capacity, string city)
        {
            Location = location;
            Type = type;
            Cost = cost;
            Tax = tax;
            Profit = profit;
            Capacity = capacity;
            City = city;
        }
    }
}
