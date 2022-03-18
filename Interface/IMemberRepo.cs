using System.Collections.Generic;
using Hello_World_Razor_Page.Models;

namespace Hello_World_Razor_Page.Interface
{
    public interface IMemberRepo
    {
        IEnumerable<Member> GetallMembers();
        void AddMember(Member member);
        Member GetMember(int id);
        void RemoveMember(Member member);
        void EditMember(Member member);
    }
}