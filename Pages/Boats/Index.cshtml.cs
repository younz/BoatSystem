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
    public class IndexModel : PageModel
    {
       // private BoatReposetory _reposetory;
       private IBoats reposetory;
       public List<Boat> Boats { get; private set; }
        public string Criteria { get; set; }

        public IndexModel(IBoats repo)
        {
            reposetory = repo;
        }
        public async Task OnGet()
        {
            Boats = await reposetory.GetAllBoats();
            if (!string.IsNullOrEmpty(Criteria))
            {
                Boats = FilteredBoats(Criteria);
            }
        }

        private List<Boat> FilteredBoats(string criteria)
        {

            return new List<Boat>();
        }
    }
}
