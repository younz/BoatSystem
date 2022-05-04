using System;
using System.Threading.Tasks;
using Hello_World_Razor_Page.Interface;
using Hello_World_Razor_Page.Models;
using Hello_World_Razor_Page.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Hello_World_Razor_Page.Pages.Boats
{
    public class EditPageModel : PageModel
    {
        //private BoatReposetory _reposetory;
        private IBoats repo;
        [BindProperty] public Boat BoatEdit { get; set; }

        public EditPageModel(IBoats reposetory)
        {
            repo = reposetory;
        }
        public async Task OnGet(int id)
        {
            BoatEdit = await repo.GetById(id);
        }

        public async Task<IActionResult> OnPost()
        {  
            if (!ModelState.IsValid)
            {
                return Page();
            }
            await repo.EditBoat(BoatEdit);
            return RedirectToPage("Index");
        }
    }
}
