using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Hello_World_Razor_Page.Helpers;
using Hello_World_Razor_Page.Interface;
using Hello_World_Razor_Page.Models;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace Hello_World_Razor_Page.Services
{
    public class Boatservices:Connection, IBoats
    {
        private string _GetAllBoats = "select * from Boat";
        private string _GetById = "select * from Boat where BoatNumber = @ID";
        private string _AddBoat = "insert into Boat Values (@ID, @Name, @Model)";
        private string _RemoveBoat = "delete from Boat where BoatNumber = @ID";
        private string _EditBoat = "Update Boat set boat BoatNumber = @ID,  @Name, @Model";
        public List<Boat> Boats { get; set; }
        public Boat ListBoat { get; set; }

        public Boatservices(IConfiguration configuration) : base(configuration)
        {
            
        }
        public async Task<IEnumerable<Boat>> GetAllBoats()
        {
            using (SqlConnection sqlConnection =new SqlConnection(ConnectionString))
            {
                using (SqlCommand command =new SqlCommand(_GetAllBoats,sqlConnection))
                {
                    await command.Connection.OpenAsync();
                    SqlDataReader reader = await command.ExecuteReaderAsync();
                    while (await reader.ReadAsync())
                    {
                        
                    }
                }
            }
            throw new NotImplementedException();
        }


        public Task<bool> AddBoat(Boat boat)
        {
            throw new NotImplementedException();
        }

        public Task<bool> EditBoat(Boat boat)
        {
            throw new NotImplementedException();
        }

        public Task<Boat> GetById(int num)
        {
            throw new NotImplementedException();
        }

        public Task<Boat> RemoveBoat(Boat boat)
        {
            throw new NotImplementedException();
        }
    }
}
