using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Hello_World_Razor_Page.Interface;
using Hello_World_Razor_Page.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Hello_World_Razor_Page.Pages.Members
{
    public class CreateMemberModel : PageModel
    {
        //private IMemberRepo repo;
        private IMembers repo;
        [BindProperty] public Member member { get; set; }

        public CreateMemberModel(IMembers memberRepo)
        {
            repo = memberRepo;
        }
        public IActionResult OnGet()
        {
            return Page();
        }

        public async Task<IActionResult> OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            await repo.AddMember(member);
            return RedirectToPage("Index");
        }
    }
}
