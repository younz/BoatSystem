using System.Collections.Generic;
using System.Linq;
using Hello_World_Razor_Page.Interface;
using Hello_World_Razor_Page.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Hello_World_Razor_Page.Pages.Bookings
{
    public class IndexModel : PageModel
    {
        private IBookingRepo instance;
        public List<Booking> SBookings { get; private set; }
        public IndexModel(IBookingRepo booking)
        {
            instance = booking;
        }
        public void OnGet()
        {
            SBookings = instance.GetAllBookings().ToList();
        }
    }
}
