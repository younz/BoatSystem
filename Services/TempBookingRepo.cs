using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;
using Hello_World_Razor_Page.Interface;
using Hello_World_Razor_Page.Models;

namespace Hello_World_Razor_Page.Services
{
    public class TempBookingRepo
    {
        private IMemberRepo member;
        private IBoatReposetory boat;
        private Boat tempBoat;
        private Member tempMember;
        private Dictionary<int, Booking> bookingsHolder { get; }
        public TempBookingRepo()
        {
            bookingsHolder = new Dictionary<int, Booking>();
            bookingsHolder.Add(2,
                new Booking(boatId: tempBoat.BoatId, bookingId: 2, confirmation: true,
                    date: new DateTime(2022, 5, 16).ToLocalTime(), memberNumber: tempMember.MemberNumber));
            bookingsHolder.Add(5,
                new Booking(boatId: tempBoat.BoatId, bookingId: 5, confirmation: true,
                    date: new DateTime(2022, 6, 3).ToLocalTime(), memberNumber: tempMember.MemberNumber));
        }

        public IEnumerable<Booking> GetAllBookings()
        {
            return bookingsHolder.Values;
        }

        public void AddBooking( Booking booking)
        {
            int id;
            List<int> bookIdHolder = new List<int>();
            foreach (var VARIABLE in bookingsHolder)
            {
                bookIdHolder.Add(VARIABLE.Key);
            }

            if (bookIdHolder.Count!=0)
            {
                int start = bookIdHolder.Max();
               id = start + 1;
               booking.BookingId = id;
            }
            else
            {
                id = 1;
                booking.BookingId = id;
            }
            bookingsHolder.Add(id,booking);
        }

        public void RemoveBooking()
        {

        }

        public Booking GetSpecificBooking(int id)
        {
            return null;
        }

    }
}
