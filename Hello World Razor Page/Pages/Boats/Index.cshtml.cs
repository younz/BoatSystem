using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Hello_World_Razor_Page.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Hello_World_Razor_Page.Pages.Boats
{
    public class IndexModel : PageModel
    {
        private FakeBoatReposetory _reposetory;
        public List<Boat> Boats { get; private set; }

        public IndexModel()
        {
            _reposetory = new FakeBoatReposetory();
        }
        public void OnGet()
        {
            Boats = _reposetory.GetAllBoats().ToList();
        }
    }
}
