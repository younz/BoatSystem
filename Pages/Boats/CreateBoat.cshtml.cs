using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Hello_World_Razor_Page.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Hello_World_Razor_Page.Pages.Boats
{
    public class CreateBoatModel : PageModel
    {
        private FakeBoatReposetory _repository;
        [BindProperty]
        public Boat Boat { get; set; }

        public CreateBoatModel()
        {
            _repository = FakeBoatReposetory.Instance;
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
            _repository.AddBoat(Boat);
            return RedirectToPage("Index");
        }
    }
}
