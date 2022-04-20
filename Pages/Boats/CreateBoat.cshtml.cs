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
    public class CreateBoatModel : PageModel
    {
       //private BoatReposetory _repository;
       private IBoatReposetory repo; 
       [BindProperty]
        public Boat Boat { get; set; }

        public CreateBoatModel(IBoatReposetory reposetory )
        {
            repo = reposetory;
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
            repo.AddBoat(Boat);
            return RedirectToPage("Index");
        }
    }
}
