using System.Collections.Generic;
using System.Threading.Tasks;
using Hello_World_Razor_Page.Interface;
using Hello_World_Razor_Page.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Hello_World_Razor_Page.Pages.Bookings
{
    public class CreateNewBookingModel : PageModel
    {
        private IBooking bookings;
        private IBoats _boats;
        private IMembers members;
        [BindProperty] public Booking Booking { get; set; }
        public List<SelectListItem> BoatItems { get; set; }
        public List<SelectListItem> MemberItems { get; set; }

        public CreateNewBookingModel(IBooking repo,IMembers member,IBoats iBoats)
        {
            bookings = repo;
            members = member;
            _boats = iBoats;
            Booking = new Booking();
        }

        public async Task<IActionResult> OnGet()
        {
            List<Member> member = await members.GetAllMembers();
            List<Boat> boats = await _boats.GetAllBoats();
            BoatItems = new List<SelectListItem>();
            MemberItems = new List<SelectListItem>();
            foreach (var b in boats)
            {
                SelectListItem s = new SelectListItem(b.BoatName, b.BoatId.ToString());
                BoatItems.Add(s);
            }

            foreach (var m in member)
            {
                SelectListItem t = new SelectListItem(m.MemberName, m.MemberNumber.ToString());
                MemberItems.Add(t);
            }
            return Page();

        }

        public async Task<IActionResult> OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            //Bookings.confirmation = true;
            await bookings.AddBooking(Booking);
            return RedirectToPage("Index");
        }
    }
}
