using System;
using Hello_World_Razor_Page.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Hello_World_Razor_Page.Pages.Boats
{
    public class EditPageModel : PageModel
    {
        private FakeBoatReposetory _reposetory;
        [BindProperty] public Boat BoatEdit { get; set; }

        public EditPageModel()
        {
                _reposetory = FakeBoatReposetory.Instance;
        }
        public void OnGet(int id)
        {
            BoatEdit = _reposetory.GetById(id);
            
        }

        public IActionResult OnPost()
        {  
            if (!ModelState.IsValid)
            {
                return Page();
            }
            _reposetory.EditBoat(BoatEdit);
            return RedirectToPage("Index");
        }
    }
}
