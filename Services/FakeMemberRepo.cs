using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Hello_World_Razor_Page.Interface;
using Hello_World_Razor_Page.Models;

namespace Hello_World_Razor_Page.Services
{
    public class FakeMemberRepo : IMemberRepo
    {
        private List<Member> membersList { get; }
        //private Dictionary<int, Member> MembersdDictionary { get; }

        public FakeMemberRepo()
        {
            membersList = new List<Member>();
            membersList.Add(new Member()
                {
                    Address = "Åmosevej 9, 3400 Hillerød",Email = "Email@email.com",MemberNumber = 5,
                    MemberName = "Jens Jensen",Password = "Something",PhoneNumber = 24856132
                });
            membersList.Add(new Member()
            {
                Address = "Lütkensvej 2, 3400 Hillerød",Email = "Janus@email.com",MemberNumber = 1,
                MemberName = "Hans Hansen",Password = "Words",PhoneNumber = 25463197
            });
            /* Member = new Dictionary<int, Member>();
             MembersdDictionary.Add(0,new Member()
             {
                 Id = 0,MemberName = "",Address = "",Email = "",Password = "",PhoneNumber = 32658574
             });
             MembersdDictionary.Add(1, new Member()
             {
                 Id = 1,MemberName = "",Address = "",Email = "",Password = "", PhoneNumber = 35616485
             });*/
        }

      /*  public Dictionary<int, Member> GetallMembers()
        {
            return null;
        }*/
      public IEnumerable<Member> GetallMembers()
      {
          return membersList.ToList();
      }

      public void AddMember(Member member)
      {
          List<int> memberids = new List<int>();
          foreach (var VARIABLE in membersList)
          {
              memberids.Add(VARIABLE.MemberNumber);
          }

          if (memberids.Count !=0)
          {
              int start = memberids.Max();
              member.MemberNumber = start+1;
          }
          else
          {
              member.MemberNumber = 1;
          }
          membersList.Add(member);
      }

        public Member GetMember(int id)
        {
            Member tempMember = null;
            foreach (var VARIABLE in membersList)
            {
                if (VARIABLE.MemberNumber ==id)
                {
                    tempMember = VARIABLE;
                }
            }

            return tempMember;
        }

        public void RemoveMember(Member member)
        {
            Member temp = GetMember(member.MemberNumber);
            membersList.Remove(temp);
        }

        public void EditMember(Member member)
        {
            if (member != null)
            {
                foreach (var VARIABLE in membersList)
                {
                    if (VARIABLE.MemberNumber == member.MemberNumber)
                    {
                        VARIABLE.Address = member.Address;
                        VARIABLE.Email = member.Email;
                        VARIABLE.MemberName = member.MemberName;
                        VARIABLE.Password = member.Password;
                        VARIABLE.PhoneNumber = member.PhoneNumber;
                        VARIABLE.MemberNumber = member.MemberNumber;
                    }
                }
            }
        }
    }
}
