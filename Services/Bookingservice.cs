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
    public class Bookingservice : Connection,IBooking
    {

        private string _GetAllBookings = "select * from Booking";
        private string _GetById = "select * from Member where BookingId = @ID";
        private string _AddBooking = "insert into Booking Values (@ID, @MemberID, @BoatID,@BookingDate)";
        private string _RemoveBooking = "delete from Booking where BookingId = @ID";
        private string _EditMember = "Update Booking " +
                                     "set BookingId = @ID, MemberNumber = @MemberID, BoatNumber = @BoatID, BookingDate = @BookingDate" +
                                     " where BookingId = @ID";
        public Bookingservice(IConfiguration configuration) : base(configuration)
        {
        }

        public async Task<IEnumerable<Booking>> GetAllBookings()
        {
            List<Booking> bookings = new List<Booking>();
            await using (SqlConnection connection =new SqlConnection(ConnectionString))
            {
                await using (SqlCommand command = new SqlCommand(_GetAllBookings, connection))
                {
                    try
                    {
                        await command.Connection.OpenAsync();
                    SqlDataReader reader = await command.ExecuteReaderAsync();
                    while (await reader.ReadAsync())
                    {
                        Booking booking = new Booking();
                        booking.BookingId = reader.GetInt32(0);
                        booking.MemberNumber = reader.GetInt32(1);
                        booking.BoatId = reader.GetInt32(2);
                        booking.Date = reader.GetDateTime(3);
                        bookings.Add(booking);
                    }
                    }
                    catch (Exception e)
                    {
                     
                        throw new Exception("der skete en ukendt fejl");
                    }

                }
            }

            return bookings.ToList();
           
        }

        public async Task<bool> AddBooking(Booking booking)
        {
            List<Booking> currentBookings = await GetAllBookings() as List<Booking>;
            List<int> bookingId = new List<int>();
            foreach (var VARIABLE in currentBookings)
            {
                bookingId.Add(VARIABLE.BookingId);
            }

            if (bookingId.Count != 0)
            {
                int start = bookingId.Max();
                booking.BookingId = start + 1;
            }
            else
            {
                booking.BookingId = 1;
            }

            await using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                await using (SqlCommand command = new SqlCommand(_AddBooking, connection))
                {
                    command.Parameters.AddWithValue("@ID",booking.BookingId);
                    command.Parameters.AddWithValue("@MemberID", booking.MemberNumber);
                    command.Parameters.AddWithValue("@BoatID",booking.BoatId);
                    command.Parameters.AddWithValue("@BookingDate", booking.Date);
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

        public async Task<Booking> RemoveBooking(Booking booking)
        {
            if (booking != null)
            {
                await using (SqlConnection connection = new SqlConnection(ConnectionString))
                {
                    await using (SqlCommand command = new SqlCommand(_RemoveBooking, connection))
                    {
                        command.Parameters.AddWithValue("@ID", booking.BookingId);
                        await command.Connection.OpenAsync();
                        var NoOfRows = command.ExecuteNonQuery();
                        if (NoOfRows ==1)
                        {
                            return booking;
                        }

                        return null;
                    }
                }
            }

            return null;
        }

        public async Task<Booking> GetSpecificBooking(int id)
        {
            await using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                await using (SqlCommand command = new SqlCommand(_GetById, connection))
                {
                    try
                    {
                        command.Parameters.AddWithValue("@ID", id);
                        await command.Connection.OpenAsync();
                        SqlDataReader reader = await command.ExecuteReaderAsync();
                        if (await reader.ReadAsync())
                        {
                            Booking booking = new Booking();
                            booking.BookingId = reader.GetInt32(0);
                            booking.MemberNumber = reader.GetInt32(1);
                            booking.BoatId = reader.GetInt32(2);
                            booking.Date = reader.GetDateTime(3);
                            return booking;
                        }
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e);
                        throw;
                    }
                }
            }

            return null;
        }

        public async Task<bool> EditBooking(Booking booking)
        {
            await using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                await using (SqlCommand command = new SqlCommand(_EditMember, connection))
                {
                    command.Parameters.AddWithValue("@ID", booking.BookingId);
                    command.Parameters.AddWithValue("@MemberID", booking.MemberNumber);
                    command.Parameters.AddWithValue("@BoatID", booking.BoatId);
                    command.Parameters.AddWithValue("@BookingDate", booking.Date);
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
