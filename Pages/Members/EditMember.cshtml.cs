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
        private IMemberRepo memberEdit;

        public EditMemberModel(IMemberRepo repo)
        {
            memberEdit = repo;
        }

        public void OnGet(int id)
        {
            Members = memberEdit.GetMember(id);
        }

        public IActionResult OnPost()
        {
            
            if (!ModelState.IsValid)
            {
                return Page();
            }
            memberEdit.EditMember(Members);
            return RedirectToPage("Index");
        }
    }
}
