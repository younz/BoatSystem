using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Hello_World_Razor_Page.Helpers;
using Hello_World_Razor_Page.Interface;
using Hello_World_Razor_Page.Models;
using Microsoft.Extensions.Configuration;

namespace Hello_World_Razor_Page.Services
{
    public class Boatservices:Connection, IBoatReposetory
    {
        private string _GetAllBoats = "select * from Boat";
        public Boatservices(IConfiguration configuration) : base(configuration)
        {
        }

        public IEnumerable<Boat> GetAllBoats()
        {
            throw new NotImplementedException();
        }

        public void AddBoat(Boat boat)
        {
            throw new NotImplementedException();
        }

        public void RemoveBoat(Boat boat)
        {
            throw new NotImplementedException();
        }

        public Boat GetById(int num)
        {
            throw new NotImplementedException();
        }

        public void EditBoat(Boat boat)
        {
            throw new NotImplementedException();
        }
    }
}
