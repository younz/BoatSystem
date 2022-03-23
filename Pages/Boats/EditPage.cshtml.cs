using System;
using Hello_World_Razor_Page.Interface;
using Hello_World_Razor_Page.Models;
using Hello_World_Razor_Page.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Hello_World_Razor_Page.Pages.Boats
{
    public class EditPageModel : PageModel
    {
        //private FakeBoatReposetory _reposetory;
        private IBoatReposetory repo;
        [BindProperty] public Boat BoatEdit { get; set; }

        public EditPageModel(IBoatReposetory reposetory)
        {
            repo = reposetory;
        }
        public void OnGet(int id)
        {
            BoatEdit = repo.GetById(id);
        }

        public IActionResult OnPost()
        {  
            if (!ModelState.IsValid)
            {
                return Page();
            }
            repo.EditBoat(BoatEdit);
            return RedirectToPage("Index");
        }
    }
}
