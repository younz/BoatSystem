using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Hello_World_Razor_Page.Models;

namespace Hello_World_Razor_Page.Interface
{
    public interface IBooking
    {
        Task<IEnumerable<Booking>> GetAllBookings();
        Task<bool> AddBooking( Booking booking);
        Task<Booking> RemoveBooking( Booking booking);
        Task<Booking> GetSpecificBooking(int id); 
        Task<bool> EditBooking(Booking booking);
    }
}
