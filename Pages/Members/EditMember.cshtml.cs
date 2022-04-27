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
    public class EditMemberModel : PageModel
    {
        [BindProperty] public Member Members { get; set; }
        private IMembers memberEdit;

        public EditMemberModel(IMembers repo)
        {
            memberEdit = repo;
        }

        public async Task OnGet(int id)
        {
            Members = await memberEdit.GetMember(id);
        }

        public async Task<IActionResult> OnPost()
        {
            
            if (!ModelState.IsValid)
            {
                return Page();
            }
            await memberEdit.EditMember(Members);
            return RedirectToPage("Index");
        }
    }
}
