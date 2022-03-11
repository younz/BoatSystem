using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Hello_World_Razor_Page.Pages.Boats;

namespace Hello_World_Razor_Page.Models
{
    public class FakeBoatReposetory
    {
        private List<Boat> Boats { get; }
        private static FakeBoatReposetory _instance;

        private FakeBoatReposetory()
        {
            Boats = new List<Boat>();


            Boats.Add(new Boat()
            {
                BoatId = 5, BoatName = "Jannata", Model = BoatModels.Feva
            });
            Boats.Add(new Boat()
            {
                BoatId = 8, BoatName = "Jekata", Model = BoatModels.Lynæs
            });

        }

        public static FakeBoatReposetory Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new FakeBoatReposetory();
                }

                return _instance;
            }
        }
        public IEnumerable<Boat> GetAllBoats()
        {
            return Boats.ToList();
        }

        public void AddBoat(Boat boat)
        {
            List<int> boatId = new();
            foreach (Boat evtBoat in Boats)
            {
                boatId.Add(evtBoat.BoatId);
            }

            if (boatId.Count != 0)
            {
                int start = boatId.Max();
                boat.BoatId = start + 1;
            }
            else
            {
                boat.BoatId = 1;
            }

            Boats.Add(boat);
        }
        public void RemoveBoat(Boat boat)
         {
             Boat tempBoat = GetById(boat.BoatId);
           /*  foreach (Boat variable in _boats)
             {
                 if (boat.BoatId == variable.BoatId)
                 {
                     tempBoat = boat;
                     
                    break;
                 }
             }*/
             Boats.Remove(tempBoat);
             
            
         }
       public Boat GetById(int num)
       {
           Boat tempBoat = null;
             foreach (Boat variable in Boats)
             {
                 if (num == variable.BoatId)
                 {
                     tempBoat = variable;
                 }
             }

             return tempBoat;
       }

       public void EditBoat(Boat boat)
       {
           if (boat != null)
           {
               foreach (var oldBoat in Boats)
               {
                   if (oldBoat.BoatId == boat.BoatId)
                   {
                       oldBoat.BoatId = boat.BoatId;
                       oldBoat.BoatName = boat.BoatName;
                       oldBoat.Model = boat.Model;
                   }
               }
           }
       }
    }
}
