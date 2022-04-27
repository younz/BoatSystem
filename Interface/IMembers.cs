using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Hello_World_Razor_Page.Models;

namespace Hello_World_Razor_Page.Interface
{
    public interface IMembers
    {
        Task<List<Member>> GetAllMembers();
        Task<bool> AddMember(Member member);
        Task<Member> GetMember(int id);
        Task<Member> RemoveMember(Member member);
        Task<bool> EditMember(Member member);
    }
}
