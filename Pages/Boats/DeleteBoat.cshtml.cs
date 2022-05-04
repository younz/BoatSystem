using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Hello_World_Razor_Page.Interface;
using Hello_World_Razor_Page.Models;
using Hello_World_Razor_Page.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Hello_World_Razor_Page.Pages.Boats
{
    public class DeleteBoatModel : PageModel
    {
        private IBoats repo;
        [BindProperty] public Boat RBoat { get; set; }

        public DeleteBoatModel(IBoats reposetory)
        {
            repo = reposetory;
        }
        public async Task OnGet(int id)
        {
            RBoat = await repo.GetById(id);
        }

        public async Task<IActionResult> OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
                
            }
            await repo.RemoveBoat(RBoat);
            return RedirectToPage("Index");
        }
    }
}
