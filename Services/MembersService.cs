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
    public class MembersService: Connection, IMembers 
    {
        private string _GetAllMembers = "select * from Member";
        private string _GetById = "select * from Member where MemberNumber = @ID";
        private string _AddMember = "insert into Member Values (@ID, @Name, @Address, @Mail, @Number, @Password)";
        private string _RemoveMember = "delete from Member where MemberNumber = @ID";
        private string _EditMember = "Update Member " +
                                   "set MemberNumber = @ID, Name= @Name, Address = @Address," +
                                   " Email = @Mail, PhoneNumber = @Number, USERPassword = @Password" +
                                   "where MemberNumber = @ID";

        public MembersService(IConfiguration configuration) : base(configuration)
        {
        }

        public async Task<List<Member>> GetAllMembers()
        {
            List<Member> members = new List<Member>();
            await using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                await using (SqlCommand command = new SqlCommand(_GetAllMembers,connection))
                {
                    await command.Connection.OpenAsync();
                    SqlDataReader reader = await command.ExecuteReaderAsync();
                    while (await reader.ReadAsync())
                    {
                        Member lisMember = new Member();
                        lisMember.MemberNumber = reader.GetInt32(0);
                        lisMember.MemberName = reader.GetString(1);
                        lisMember.Address = reader.GetString(2);
                        lisMember.Email = reader.GetString(3);
                        lisMember.PhoneNumber = reader.GetString(4);
                        lisMember.Password = reader.GetString(5);
                        members.Add(lisMember);
                    }
                }
            }

            return members.ToList();
        }

        public async Task<bool> AddMember(Member member)
        {
            List<Member> currenMembers = await GetAllMembers();
            List<int> memberInts = new List<int>();
            foreach (var VARIABLE in currenMembers)
            {
                memberInts.Add(VARIABLE.MemberNumber);
            }

            if (memberInts.Count != 0)
            {
                int start = memberInts.Max();
                member.MemberNumber = start + 1;
            }
            else
            {
                member.MemberNumber = 1;
            }

            await using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                await using (SqlCommand command =new SqlCommand(_AddMember,connection))
                {
                    command.Parameters.AddWithValue("@ID", member.MemberNumber);
                    command.Parameters.AddWithValue("@Name",member.MemberName);
                    command.Parameters.AddWithValue("@Address", member.Address);
                    command.Parameters.AddWithValue("@Mail", member.Email);
                    command.Parameters.AddWithValue("@Number", member.PhoneNumber);
                    command.Parameters.AddWithValue("@Password", member.Password);
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

        public async Task<Member> GetMember(int id)
        {
            await using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                await using (SqlCommand command = new SqlCommand(_GetById, connection))
                {
                    command.Parameters.AddWithValue("@ID",id);
                    await command.Connection.OpenAsync();
                    SqlDataReader reader = await command.ExecuteReaderAsync();
                    if (await reader.ReadAsync())
                    {
                        int memberId = reader.GetInt32(0);
                        string Name = reader.GetString(1);
                        string Address = reader.GetString(2);
                        string Email = reader.GetString(3);
                        string PhoneNumber = reader.GetString(4);
                        string Pass = reader.GetString(5);
                        Member member = new Member(memberId, Name, Address, Email, PhoneNumber, Pass);
                        return member;
                    }
                }
            }
            return null;
        }

        public async Task<Member> RemoveMember(Member member)
        {
            if (member != null)
            {
                
                await using (SqlConnection connection = new SqlConnection(ConnectionString))
                {
                    await using (SqlCommand command = new SqlCommand(_RemoveMember, connection))
                    {
                        command.Parameters.AddWithValue("@ID", member.MemberNumber);
                        await command.Connection.OpenAsync();

                        var noOfRows = command.ExecuteNonQuery();
                        if (noOfRows == 1)
                        {
                            return member;
                        }

                        return null;
                    }
                }
            }

            return null;
        }

        public async Task<bool> EditMember(Member member)
        {
            await using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                await using (SqlCommand command = new SqlCommand(_EditMember, connection))
                {
                    command.Parameters.AddWithValue("@ID", member.MemberNumber);
                    command.Parameters.AddWithValue("@Name",member.MemberName);
                    command.Parameters.AddWithValue("@Address", member.Address);
                    command.Parameters.AddWithValue("@Mail", member.Email);
                    command.Parameters.AddWithValue("@Number", member.PhoneNumber);
                    command.Parameters.AddWithValue("@Password", member.Password);
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
    }
}
