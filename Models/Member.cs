using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Hello_World_Razor_Page.Models
{
    public class Member
    {
      

        public Member()
        {
        }

        public Member(int memberId, string name, string address, string email, string phoneNumber, string pass)
        {
            MemberNumber= memberId;
            MemberName = name;
            Address = address;
            Email = email;
            PhoneNumber = phoneNumber;
            Password = pass;
        }

        [Required(ErrorMessage = "Please write you name")]
        public string MemberName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        [Required(AllowEmptyStrings = false)]
        public string Password { get; set; }
        public int MemberNumber { get; set; }
        public override bool Equals(object? obj)
        {
            if (obj is Member)
            {
                var abBoat = (Member)obj;
                if (abBoat.MemberNumber == this.MemberNumber)
                {
                    return true;
                }
            }
            return false;
        }
    }
    
}
