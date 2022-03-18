using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Hello_World_Razor_Page.Models
{
    public enum BoatModels // måske lav dette om til en klasse evt.
    {
       Tera,
       Feva,
       Laserjolle,
       Europajolle,
       Snipejolle,
       Wayfarer,
       Lynæs
    }
    public class Boat
    {
        [Display(Name = "Boat Name")]
        [Required(ErrorMessage = "Name on the boat is required"),MaxLength(30)]
        public string BoatName { get; set; }

        public int BoatId { get; set; }

        //public int Size { get; set; }

        public override bool Equals(object? obj)
        {
            if (obj is Boat)
            {
                Boat abBoat = (Boat)obj;
                if (abBoat.BoatId == this.BoatId)
                {
                    return true;
                }
            }
            return false;
        }

        public BoatModels Model { get; set; }
    }
}
