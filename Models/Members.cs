using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Hello_World_Razor_Page.Models
{
    public class Members
    {
        [Required(ErrorMessage = "")]
        public string MemberName { get; set; }
        public string Email { get; set; }
        public int PhoneNumber { get; set; }
        public string Address { get; set; }
        public int Id { get; set; }  
    }
    
}
