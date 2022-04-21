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
        private string _EditBoat = "Update Boat " +
                                   "set boat BoatNumber = @ID, BoatName= @Name, Model = @Model " +
                                   "where Boatnumber = @ID";
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
                        ListBoat.BoatId = reader.GetInt32(0);
                        ListBoat.BoatName = reader.GetString(1);
                        ListBoat.Model = (BoatModels)reader.GetInt32(2);
                        Boats.Add(ListBoat);
                    }
                }
            }

            return Boats.ToList();
            
        }


        public async Task<bool> AddBoat(Boat boat)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand command = new SqlCommand(_AddBoat, connection))
                {
                    command.Parameters.AddWithValue("@ID", boat.BoatId);
                    command.Parameters.AddWithValue("@Name", boat.BoatName);
                    command.Parameters.AddWithValue("@Model", (int)boat.Model);
                    await command.Connection.OpenAsync();
                    int noOfRows = command.ExecuteNonQuery();
                    if (noOfRows == 1)
                    {
                        return true;
                    }
                   
                }
            }

            return false;
        }

        public async Task<bool> EditBoat(Boat boat)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand command = new SqlCommand(_EditBoat,connection))
                {
                    command.Parameters.AddWithValue("@ID",boat.BoatId);
                    command.Parameters.AddWithValue("@Name", boat.BoatName);
                    command.Parameters.AddWithValue("@Model", (int)boat.Model);
                   await command.Connection.OpenAsync();
                    int NoOfRow = command.ExecuteNonQuery();
                    if (NoOfRow ==1)
                    {
                        return true;
                    }
                }
            }

            return false;
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
