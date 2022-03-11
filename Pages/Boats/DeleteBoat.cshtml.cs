using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Hello_World_Razor_Page.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Hello_World_Razor_Page.Pages.Boats
{
    public class DeleteBoatModel : PageModel
    {
        private FakeBoatReposetory _boatReposetory;
        [BindProperty] public Boat RBoat { get; set; }

        public DeleteBoatModel()
        {
            _boatReposetory = FakeBoatReposetory.Instance;
        }
        public void OnGet(int id)
        {
            RBoat = _boatReposetory.GetById(id);
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
                
            }
            _boatReposetory.RemoveBoat(RBoat);
            return RedirectToPage("Index");
        }
    }
}
