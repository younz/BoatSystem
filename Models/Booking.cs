using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hello_World_Razor_Page.Models
{
    public class Booking
    {
        public Booking(int boatId, int bookingId, bool confirmation, DateTime date, int memberNumber)
        {
            BoatId = boatId;
            BookingId = bookingId;
            this.confirmation = confirmation;
            Date = date;
            MemberNumber = memberNumber;
        }

        public int BookingId { get; set; }
        public DateTime Date { get; set; } = DateTime.Today.ToLocalTime();
        public bool confirmation { get; set; } = false;
        
        public int BoatId { get; set; }

        public int MemberNumber { get; set; }

    }
}
