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
            JsonFileWriter.WriteToJsonBoat(adingBoats,filePath);
        }

        public void RemoveBoat(Boat boat)
        {
            if (boat!= null)
            {
                
                List<Boat> removeBoats = GetAllBoats().ToList();
                removeBoats.Remove(boat);

                JsonFileWriter.WriteToJsonBoat(removeBoats,filePath);
            }
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
                List<Boat> updateBoats = GetAllBoats().ToList();
                foreach (var oldBoat in updateBoats)
                {
                    if (oldBoat.BoatId == boat.BoatId)
                    {
                        oldBoat.BoatId = boat.BoatId;
                        oldBoat.BoatName = boat.BoatName;
                        oldBoat.Model = boat.Model;
                    }
                }
                JsonFileWriter.WriteToJson(updateBoats,filePath);
            }
            
        }
    }
}
