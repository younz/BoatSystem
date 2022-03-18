using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Hello_World_Razor_Page.Models
{
    public class Member
    {
        [Required(ErrorMessage = "Please write you name")]
        public string MemberName { get; set; }
        public string Email { get; set; }
        public int PhoneNumber { get; set; }
        public string Address { get; set; }
        [Required(AllowEmptyStrings = false)]
        public string Password { get; set; }
        public int Id { get; set; }
        public override bool Equals(object? obj)
        {
            if (obj is Member)
            {
                var abBoat = (Member)obj;
                if (abBoat.Id == this.Id)
                {
                    return true;
                }
            }
            return false;
        }
    }
    
}
