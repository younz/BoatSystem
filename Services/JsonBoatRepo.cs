using Hello_World_Razor_Page.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Hello_World_Razor_Page.Helpers;
using Hello_World_Razor_Page.Interface;

namespace Hello_World_Razor_Page.Services
{
    public class JsonBoatRepo : IBoatReposetory
    {
        private string filePath = @"C:\Users\youna\source\repos\younz\BoatSystem\Data\BoatData.json";

        public IEnumerable<Boat> GetAllBoats()
        {
            return JsonFileReader.ReadJson(filePath);
        }

        public void AddBoat(Boat boat)
        {
            List < Boat > adingBoats = GetAllBoats().ToList();
            
            List<int> boatId = new();
            foreach (Boat evtBoat in adingBoats)
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

            adingBoats.Add(boat);
            JsonFileWriter.WriteToJson(adingBoats,filePath);
        }

        public void RemoveBoat(Boat boat)
        {
            var Temp = GetById(boat.BoatId);
            List<Boat> removeBoats = GetAllBoats().ToList();
            foreach (var VARIABLE in removeBoats)
            {
                if (Temp.BoatId == VARIABLE.BoatId)
                {
                    removeBoats.Remove(Temp);
                }
            }
            JsonFileWriter.WriteToJson(removeBoats,filePath);
        }

        public Boat GetById(int num)
        {
            Boat tempBoat = null;
            foreach (Boat variable in GetAllBoats())
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
                foreach (var oldBoat in GetAllBoats())
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
