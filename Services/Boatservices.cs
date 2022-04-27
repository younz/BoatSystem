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
                                   "set BoatNumber = @ID, BoatName= @Name, Model = @Model " +
                                   "where BoatNumber = @ID";
      

        public Boatservices(IConfiguration configuration) : base(configuration)
        {
            
        }
        public async Task<List<Boat>> GetAllBoats()
        {

            List<Boat> boats = new List<Boat>();
           await using (SqlConnection sqlConnection =new SqlConnection(ConnectionString))
            {
                await using (SqlCommand command =new SqlCommand(_GetAllBoats,sqlConnection))
                {
                    await command.Connection.OpenAsync();
                    SqlDataReader reader = await command.ExecuteReaderAsync();
                    while (await reader.ReadAsync())
                    {
                        Boat boat = new Boat();
                        boat.BoatId = reader.GetInt32(0);
                        boat.BoatName = reader.GetString(1);
                        boat.Model = (BoatModels)reader.GetInt32(2);
                        boats.Add(boat);
                    }
                }
            }

            return boats.ToList();
            
        }


        public async Task<bool> AddBoat(Boat boat)
        {
            List < Boat > adingBoats = await GetAllBoats();
            
            List<int> boatId = new();
            foreach (var VARIABLE in adingBoats)
            {
                boatId.Add(VARIABLE.BoatId);
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
            await using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                await using (SqlCommand command = new SqlCommand(_AddBoat, connection))
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
            await using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                await using (SqlCommand command = new SqlCommand(_EditBoat,connection))
                {
                    command.Parameters.AddWithValue("@ID",boat.BoatId);
                    command.Parameters.AddWithValue("@Name", boat.BoatName);
                    command.Parameters.AddWithValue("@Model", (int)boat.Model);
                   await command.Connection.OpenAsync();
                    var NoOfRow = command.ExecuteNonQuery();
                    if (NoOfRow ==1)
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        public async Task<Boat> GetById(int num)
        {
            await using (SqlConnection connection =new SqlConnection(ConnectionString))
            {
                await using (SqlCommand command =new SqlCommand(_GetById,connection))
                {
                    command.Parameters.AddWithValue("@ID", num);
                    await command.Connection.OpenAsync();
                    SqlDataReader reader = await command.ExecuteReaderAsync();
                    if (await reader.ReadAsync())
                    {
                        int BoatId = reader.GetInt32(0);
                        string BoatName = reader.GetString(1);
                        BoatModels boatModel = (BoatModels)reader.GetInt32(2);
                        Boat boat = new Boat(BoatName,BoatId,boatModel);
                        return boat;
                    }
                }
            }

            return null;
        }

        public async Task<Boat> RemoveBoat(Boat boat)
        {
            if (boat !=null)
            {
                //List<Boat> boatremovaList = await GetAllBoats();
                await using (SqlConnection connection = new SqlConnection(ConnectionString))
                {
                   await using (SqlCommand command = new SqlCommand(_RemoveBoat,connection))
                   {
                        command.Parameters.AddWithValue("@ID", boat.BoatId);
                       await command.Connection.OpenAsync();
                        var noOfRows = command.ExecuteNonQuery();
                        if (noOfRows == 1)
                        {
                            return boat;
                        }

                        return null;
                   }
                }
            }

            return null;
        }
    }
}
