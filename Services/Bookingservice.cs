using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Hello_World_Razor_Page.Helpers;
using Hello_World_Razor_Page.Interface;
using Hello_World_Razor_Page.Models;
using Microsoft.Extensions.Configuration;

namespace Hello_World_Razor_Page.Services
{
    public class Bookingservice : Connection,IBooking
    {
        public Bookingservice(IConfiguration configuration) : base(configuration)
        {
        }

        public async Task<IEnumerable<Booking>> GetAllBookings()
        {
            throw new NotImplementedException();
        }

        public async Task<bool> AddBooking(Booking booking)
        {
            throw new NotImplementedException();
        }

        public async Task<Booking> RemoveBooking(Booking booking)
        {
            throw new NotImplementedException();
        }

        public async Task<Booking> GetSpecificBooking(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> EditBooking(Booking booking)
        {
            throw new NotImplementedException();
        }
    }
}
