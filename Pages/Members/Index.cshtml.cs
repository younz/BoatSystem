using System.Collections.Generic;
using System.Linq;
using Hello_World_Razor_Page.Interface;
using Hello_World_Razor_Page.Services;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Hello_World_Razor_Page.Models;

namespace Hello_World_Razor_Page.Pages.Members
{
    public class IndexModel : PageModel
    {
        private IMemberRepo repo;
        public List<Member> Members { get; private set; }

        public IndexModel(IMemberRepo repos)
        {
            repo = repos;
        }
        public void OnGet()
        {
            Members = repo.GetallMembers().ToList();
        }
    }
}
