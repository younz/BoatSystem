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
        //private IMemberRepo member;
        //private IBoatReposetory boat;
        //private Boat tempBoat;
        //private Member tempMember;
        private Dictionary<int, Booking> bookingsHolder { get; }
        public TempBookingRepo()
        {
            bookingsHolder = new Dictionary<int, Booking>();
            bookingsHolder.Add(1,
                new Booking(boatId: 7, bookingId: 1, true,
                    date: new DateTime(2022, 5, 16).ToLocalTime(), memberNumber: 6));
            bookingsHolder.Add(2,
                new Booking(boatId: 5, bookingId: 2, confirmation: true,
                    date: new DateTime(2022, 6, 3).ToLocalTime(), memberNumber: 3));
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

        public void RemoveBooking( Booking booking)
        {
            bookingsHolder.Remove(booking.BookingId);
        }

        public Booking GetSpecificBooking(int id)
        {
            Booking speceficBooking = null;
            foreach (var booking in bookingsHolder)
            {
                if (booking.Key == id )
                {
                    speceficBooking = booking.Value;
                }
            }
            return speceficBooking;
        }

        public void EditBooking(Booking booking)
        {
            
            if (booking !=null)
            {
                foreach (var VARIABLE in bookingsHolder)
                {
                    if (VARIABLE.Key ==booking.BookingId)
                    {
                        VARIABLE.Value.BoatId = booking.BoatId;
                        VARIABLE.Value.MemberNumber = booking.MemberNumber;
                        VARIABLE.Value.BookingId = booking.BookingId;
                        VARIABLE.Value.Date = booking.Date;
                        VARIABLE.Value.confirmation = booking.confirmation;
                    } 
                }
            }
        }

    }
}
