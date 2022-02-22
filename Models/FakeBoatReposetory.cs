using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Hello_World_Razor_Page.Pages.Boats;

namespace Hello_World_Razor_Page.Models
{
    public class FakeBoatReposetory
    {
        private List<Boat> _boats { get;}
        private static FakeBoatReposetory _instance;

        private FakeBoatReposetory()
        {
            _boats = new List<Boat>();


            _boats.Add(new Boat()
            {
                BoatId = 5, BoatName = "Jannata", Model = BoatModels.Feva
            });
            _boats.Add(new Boat()
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
            return _boats.ToList();
        }

        public void AddBoat(Boat boat)
        {
            List<int> boatId = new();
            foreach (Boat evtBoat in _boats)
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

            _boats.Add(boat);
        }
         public void RemoveBoat(int id)
         {
             foreach (var VARIABLE in _boats)
             {
                 if (id == VARIABLE.BoatId) 
                 {
                     _boats.Remove(VARIABLE);
                    
                 }
             }
         }
       public Boat GetByID(int num)
       {
           Boat tempBoat = null;
             foreach (Boat VARIABLE in _boats)
             {
                 if (num == VARIABLE.BoatId)
                 {
                     tempBoat = VARIABLE;
                 }
             }

             return tempBoat;
       }

       public void EditBoat(Boat boat)
       {
           if (boat != null)
           {
               foreach (var oldBoat in _boats)
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
