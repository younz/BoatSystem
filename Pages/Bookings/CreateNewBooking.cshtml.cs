using Hello_World_Razor_Page.Interface;
using Hello_World_Razor_Page.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Hello_World_Razor_Page.Pages.Bookings
{
    public class CreateNewBookingModel : PageModel
    {
        private IBookingRepo bookings;
        private IBoatReposetory boats;
        private IMemberRepo members;
        [BindProperty] public Booking Booking { get; set; }

        public CreateNewBookingModel(IBookingRepo repo,IMemberRepo member,IBoatReposetory iBoats)
        {
            bookings = repo;
            members = member;
            boats = iBoats;
            Booking = new Booking();
        }
        public IActionResult OnGet()
        {
            return Page();
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            //Bookings.confirmation = true;
            bookings.AddBooking(Booking);
            return RedirectToPage("Index");
        }
    }
}
