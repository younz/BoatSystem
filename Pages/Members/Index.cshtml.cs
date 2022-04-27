using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Hello_World_Razor_Page.Interface;
using Hello_World_Razor_Page.Services;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Hello_World_Razor_Page.Models;

namespace Hello_World_Razor_Page.Pages.Members
{
    public class IndexModel : PageModel
    {
        //private IMemberRepo repo;
        private IMembers repo;
        public List<Member> Members { get; private set; }

        public IndexModel(IMembers repos)
        {
            repo = repos;
        }
        public async Task OnGet()
        {
            Members = await repo.GetAllMembers();
        }
    }
}
