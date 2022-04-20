using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Hello_World_Razor_Page.Interface;
using Hello_World_Razor_Page.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Hello_World_Razor_Page.Pages.Bookings
{
    public class EditBookingModel : PageModel
    {
        [BindProperty]public Booking Booking { get; set; }
        private IBookingRepo _bookings;

        public EditBookingModel(IBookingRepo bookings)
        {
            _bookings = bookings;
        }

        public void OnGet(int id)
        {
           Booking= _bookings.GetSpecificBooking(id);
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            _bookings.EditBooking(Booking);
            return RedirectToPage("Index");
        }
    }
}
