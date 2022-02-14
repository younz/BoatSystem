﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Hello_World_Razor_Page.Pages.Boats;

namespace Hello_World_Razor_Page.Models
{
    public class FakeBoatReposetory
    {
        private List<Boat> _boats { get;}
        public FakeBoatReposetory()
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

        public IEnumerable<Boat> GetAllBoats()
        {
            return _boats.ToList();
        }

        public void AddBoat(Boat boat)
        {
            List<int> boatId = new();
            foreach (var evtBoat in _boats)
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
        public void RemoveBoat(Boat boat)
        {
            List<int> boatId = new();
            foreach (var evtBoat in _boats)
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
        /*public IEnumerable<Boat> GetByID( int num)
        {
            foreach (Boat VARIABLE in Members)
            {
            }
        }*/
    }
}
