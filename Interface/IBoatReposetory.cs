using System.Collections.Generic;
using Hello_World_Razor_Page.Models;

namespace Hello_World_Razor_Page.Interface
{
    public interface IBoatReposetory
    {
        // gammelt interface skal ikke bruges mere
        IEnumerable<Boat> GetAllBoats();
        void AddBoat(Boat boat);
        void RemoveBoat(Boat boat);
        Boat GetById(int num);
        void EditBoat(Boat boat);
    }
}