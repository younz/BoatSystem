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
       // private FakeBoatReposetory _reposetory;
       private IBoatReposetory reposetory;
       public List<Boat> Boats { get; private set; }
        public string Criteria { get; set; }

        public IndexModel(IBoatReposetory repo)
        {
            reposetory = repo;
        }
        public void OnGet()
        {
            Boats = reposetory.GetAllBoats().ToList();
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
