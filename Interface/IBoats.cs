using System.Collections.Generic;
using System.Threading.Tasks;
using Hello_World_Razor_Page.Models;

namespace Hello_World_Razor_Page.Interface
{
    public interface IBoats
    {
        Task<List<Boat>> GetAllBoats();
        Task <bool> AddBoat(Boat boat);
        Task<Boat> RemoveBoat(Boat boat);
        Task<Boat> GetById(int num);
        Task<bool> EditBoat(Boat boat);

    }
}