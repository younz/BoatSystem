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
    public class DeleteMemberModel : PageModel
    {
        private IMembers repo;
        [BindProperty]public Member RemoveMember{ get; set; }

        public DeleteMemberModel(IMembers tempMemberRepo)
        {
            repo = tempMemberRepo;
        }
        public async Task OnGet(int id)
        {
            RemoveMember = await repo.GetMember(id);
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            repo.RemoveMember(RemoveMember);
            return RedirectToPage("Index");
        }
    }
}
