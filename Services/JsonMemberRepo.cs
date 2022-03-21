using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Hello_World_Razor_Page.Helpers;
using Hello_World_Razor_Page.Interface;
using Hello_World_Razor_Page.Models;

namespace Hello_World_Razor_Page.Services
{
    public class JsonMemberRepo : IMemberRepo
    {
        private string filePath = @"C:\Users\youna\source\repos\younz\BoatSystem\Data\MemberData.json";

        public void AddMember(Member member)
        {
            List < Member > members = GetallMembers().ToList();
            
            List<int> memberId = new();
            foreach (Member tempMember in members)
            {
                memberId.Add(tempMember.Id);
            }

            if (memberId.Count != 0)
            {
                int start = memberId.Max();
                    member.Id = start + 1;
            }
            else
            {
                member.Id = 1;
            }

            members.Add(member);
            JsonFileWriter.WriteToJsonMember(members,filePath);
        }

        public void EditMember(Member member)
        {
            if (member != null)
            {
                List<Member> updateMembers = GetallMembers().ToList();
                foreach (var oldMember in updateMembers)
                {
                    if (oldMember.Id == member.Id)
                    {
                        oldMember.Id = member.Id;
                        oldMember.MemberName = member.MemberName;
                        oldMember.Address = member.Address;
                        oldMember.Email = member.Email;
                        oldMember.PhoneNumber = member.PhoneNumber;
                        oldMember.Password = member.Password;
                    }
                }

                JsonFileWriter.WriteToJsonMember(updateMembers, filePath);
            }
        }

        public IEnumerable<Member> GetallMembers()
        {
            return JsonFileReader.ReadMembersJson(filePath);
        }

        public Member GetMember(int id)
        {
           
           Member tempBoat = null;
            foreach (Member variable in GetallMembers())
            {
                if (id == variable.Id)
                {
                    tempBoat = variable;
                }
            }

            return tempBoat;
        }

        public void RemoveMember(Member member)
        {
            if (member!= null)
            {
                
                List<Member> removeMembers = GetallMembers().ToList();
                removeMembers.Remove(member);

                JsonFileWriter.WriteToJsonMember(removeMembers,filePath);
            }
        }
    }
}
