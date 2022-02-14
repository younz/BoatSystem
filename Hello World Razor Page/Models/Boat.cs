using System;
using System.Collections.Generic;
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
        public string BoatName { get; set; }

        public int BoatId { get; set; }

        //public int Size { get; set; }

        public BoatModels Model { get; set; }
    }
}
