using System.Collections.Generic;
using Hello_World_Razor_Page.Models;

namespace Hello_World_Razor_Page.Interface
{
    public interface ITempBookingRepo
    {
        IEnumerable<Booking> GetAllBookings();
        void AddBooking( Booking booking);
        void RemoveBooking( Booking booking);
        Booking GetSpecificBooking(int id);
        void EditBooking(Booking booking);
    }
}