using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hello_World_Razor_Page.Models
{
    public class Booking
    {
        public Booking()
        {

        }
        public Booking(int boatId, int bookingId, bool confirmation, DateTime date, int memberNumber)
        {
            BoatId = boatId;
            BookingId = bookingId;
            Confirmation = confirmation;
            Date = date;
            MemberNumber = memberNumber;
        }

        public int BookingId { get; set; }
        public DateTime Date { get; set; }
        public bool Confirmation { get; set; } 
        
        public int BoatId { get; set; }

        public int MemberNumber { get; set; }
        public override bool Equals(object? obj)
        {
            if (obj is Booking)
            {
                var overbooking = (Booking)obj;
                if (overbooking.BookingId == this.BookingId)
                {
                    return true;
                }

            }

            return false;
        }
    }
}
