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
        private IBoatReposetory repo;
        [BindProperty] public Boat RBoat { get; set; }

        public DeleteBoatModel(IBoatReposetory reposetory)
        {
            repo = reposetory;
        }
        public void OnGet(int id)
        {
            RBoat = repo.GetById(id);
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
                
            }
            repo.RemoveBoat(RBoat);
            return RedirectToPage("Index");
        }
    }
}
