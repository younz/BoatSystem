using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Hello_World_Razor_Page.Interface;
using Hello_World_Razor_Page.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Hello_World_Razor_Page.Pages.Bookings
{
    public class IndexModel : PageModel
    {
       // private IBoatReposetory boat;
       // private IMemberRepo members;
        private IBooking bookings;
        public List<Booking> SBookings { get; private set; }
        public IndexModel(IBooking booking)
        {
            bookings = booking;
            /*boat = reposetory;
            members = repo;*/
        }
        public async Task OnGet()
        {
             SBookings = bookings.GetAllBookings().Result.ToList();
           /* foreach (var VARIABLE in SBookings)
            {
                boat.GetById(VARIABLE.BoatId);
                members.GetMember(VARIABLE.MemberNumber);


            }*/
        }
    }
}
