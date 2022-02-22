using System;
using Hello_World_Razor_Page.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Hello_World_Razor_Page.Pages.Boats
{
    public class Edit_PageModel : PageModel
    {
        private FakeBoatReposetory _reposetory;
        [BindProperty] public Boat BoatEdit { get; set; }

        public void OnGet(int id)
        {
            BoatEdit = _reposetory.GetByID(id);
            
        }

        public IActionResult OnPost()
        {
            throw new NotImplementedException();
        }
    }
}
